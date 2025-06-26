using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.CarFeatureQueries;
using RentACarAPI.Application.Features.Mediator.Results.CarFeatureResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly IRepository<CarFeature> _repository;

        public GetCarFeatureByCarIdQueryHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllWithIncludeAsync(x => x.Feature, x => x.Car);
            return values.Where(f => f.CarID == request.Id).Select(x => new GetCarFeatureByCarIdQueryResult()
            {
                CarFeatureID = x.CarFeatureID,
                CarID = x.CarID,
                CarName = x.Car.Model,
                FeatureID = x.FeatureID,
                FeatureName = x.Feature.Name,
                Available = x.Available
            }).ToList();
        }
    }
}
