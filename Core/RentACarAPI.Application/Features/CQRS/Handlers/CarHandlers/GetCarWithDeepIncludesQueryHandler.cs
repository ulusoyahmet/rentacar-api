using RentACarAPI.Application.Features.CQRS.Results.CarResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace RentACarAPI.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithDeepIncludesQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarWithDeepIncludesQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarWithDeepIncludesQueryResult>> Handle()
        {
            var values = await _repository.GetAllWithExplicitIncludeAsync(
                query =>
                    query
                    .Include(x => x.Brand)
                    .Include(x => x.CarPricings)
                        .ThenInclude(cp => cp.Pricing)
            );

            return values.Select(x => new GetCarWithDeepIncludesQueryResult
            {
                CarID = x.CarID,
                BrandID = x.BrandID,
                BrandName = x.Brand.Name,
                Model = x.Model,
                CoverImageUrl = x.CoverImageUrl,
                Km = x.Km,
                Transmission = x.Transmission,
                Seat = x.Seat,
                Luggage = x.Luggage,
                Fuel = x.Fuel,
                BigImageUrl = x.BigImageUrl,
                CarPricings = x.CarPricings?.Select(cp => new CarPricingDto
                {
                    CarPricingID = cp.CarPricingID,
                    PricingID = cp.PricingID,
                    Amount = cp.Amount,
                    PricingName = cp.Pricing?.Name 
                }).ToList()
            }).ToList();

        }
    }

}
