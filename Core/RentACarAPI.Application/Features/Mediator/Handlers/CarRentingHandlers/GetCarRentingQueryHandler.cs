using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.CarRentingQueries;
using RentACarAPI.Application.Features.Mediator.Results.CarPricingResults;
using RentACarAPI.Application.Features.Mediator.Results.CarRentingResults;
using RentACarAPI.Application.Interfaces.CarRentingInterfaces;

namespace RentACarAPI.Application.CarRentings.Mediator.Handlers.CarRentingHandlers
{
    public class GetCarRentingQueryHandler: IRequestHandler<GetCarRentingQuery, List<GetCarRentingQueryResult>>
    {
        private readonly ICarRentingRepository _repository;

        public GetCarRentingQueryHandler(ICarRentingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarRentingQueryResult>> Handle(GetCarRentingQuery request,
                                            CancellationToken cancellationToken)
        {
            var cars = await _repository.GetByFilterAsync(
                x=> x.PickUpLocationID==request.LocationID 
                && x.Available == request.Available);

            return cars.Select(x => new GetCarRentingQueryResult()
            {
                BrandID = x.Car.BrandID,
                BrandName = x.Car.Brand.Name,
                Model = x.Car.Model,
                CarID = x.CarID,
                CarPricings = x.Car.CarPricings.Select(y => new CarPricingDto()
                {
                    Amount = y.Amount,
                    CarPricingID = y.CarPricingID,
                    PricingID = y.PricingID,
                    PricingName = y.Pricing.Name
                }).ToList(),
                CoverImageUrl = x.Car.CoverImageUrl,
            }).ToList();
        }
    }
}

