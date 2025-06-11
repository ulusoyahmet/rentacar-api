using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.LocationQueries;
using RentACarAPI.Application.Features.Mediator.Results.LocationResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery,
                                                            GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetLocationByIdQueryResult()
            {
                LocationID = value.LocationID,
                Name = value.Name
            };
        }
    }
}
