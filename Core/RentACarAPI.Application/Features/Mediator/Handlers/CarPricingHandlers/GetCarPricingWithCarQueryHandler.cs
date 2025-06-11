using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentACarAPI.Application.Features.Mediator.Queries.CarPricingQuries;
using RentACarAPI.Application.Features.Mediator.Results.CarPricingResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler: IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IMapper _mapper;

        public GetCarPricingWithCarQueryHandler(IRepository<Car> carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            // Using GetAllWithExplicitIncludeAsync for better control and type safety with includes.
            // Alternatively, GetAllWithDeepIncludeAsync("Brand", "CarPricings.Pricing") could be used if preferred.
            var cars = await _carRepository.GetAllWithExplicitIncludeAsync(query =>
                query.Include(c => c.Brand)
                     .Include(c => c.CarPricings!)
                         .ThenInclude(cp => cp.Pricing)
            );

            return cars.Select(x => new GetCarPricingWithCarQueryResult()
            {
                BigImageUrl = x.BigImageUrl,
                BrandID = x.BrandID,
                BrandName = x.Brand.Name,
                CarID = x.CarID,
                CarPricings = x.CarPricings.Select(y => new CarPricingDto()
                {
                    Amount = y.Amount,
                    CarPricingID = y.CarPricingID,
                    PricingID = y.PricingID,
                    PricingName = y.Pricing.Name
                }).ToList(),
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}
