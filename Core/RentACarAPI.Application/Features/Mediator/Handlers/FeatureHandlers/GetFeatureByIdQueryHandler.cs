using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.FeatureQueries;
using RentACarAPI.Application.Features.Mediator.Results.FeatureResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler: 
        IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> _repository;
        public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetFeatureByIdQueryResult()
            {
                FeatureID = value.FeatureID,
                Name = value.Name
            };
        }
    }
}
