using RentACarAPI.Application.Features.CQRS.Results.CarResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarWithBrandQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

       
        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _repository.GetAllWithIncludeAsync(x => x.Brand);

            return values.Select(x => new GetCarWithBrandQueryResult()
            {
                CarID = x.CarID,
                BrandID = x.BrandID,
                BrandName = x.Brand.Name,
                BigImageUrl = x.BigImageUrl,
                Transmission = x.Transmission,
                Seat = x.Seat,
                Model = x.Model,
                Luggage = x.Luggage,
                Km = x.Km,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel
            }).ToList();
        }
    }
}
