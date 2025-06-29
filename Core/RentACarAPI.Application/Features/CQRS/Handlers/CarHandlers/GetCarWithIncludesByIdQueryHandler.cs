using Microsoft.EntityFrameworkCore;
using RentACarAPI.Application.Features.CQRS.Queries.CarQueries;
using RentACarAPI.Application.Features.CQRS.Results.CarResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithIncludesByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarWithIncludesByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarWithIncludesByIdQueryResult> Handle(GetCarWithIncludesByIdQuery query)
        {
            var values = await _repository.GetAllWithExplicitIncludeAsync(
                query =>
                    query
                    .Include(x => x.Brand)
                    .Include(x => x.CarPricings)
                        .ThenInclude(cp => cp.Pricing)
            );

            var value = values.Where(x => x.CarID == query.Id).FirstOrDefault();

            return new GetCarWithIncludesByIdQueryResult
            {
                CarID = value.CarID,
                BrandID = value.BrandID,
                BrandName = value.Brand.Name,
                Model = value.Model,
                CoverImageUrl = value.CoverImageUrl,
                Km = value.Km,
                Transmission = value.Transmission,
                Seat = value.Seat,
                Luggage = value.Luggage,
                Fuel = value.Fuel,
                BigImageUrl = value.BigImageUrl,
                CarPricings = value.CarPricings?.Select(cp => new CarPricingDto
                {
                    CarPricingID = cp.CarPricingID,
                    PricingID = cp.PricingID,
                    Amount = cp.Amount,
                    PricingName = cp.Pricing?.Name
                }).ToList()
            };

        }
    }
}
