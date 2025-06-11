using RentACarAPI.Application.Features.CQRS.Results.CarResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCarQueryResult()
            {
                CarID = x.CarID,
                BrandID = x.BrandID,
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
