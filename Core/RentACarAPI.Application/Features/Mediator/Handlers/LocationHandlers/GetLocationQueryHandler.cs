using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.LocationQueries;
using RentACarAPI.Application.Features.Mediator.Results.LocationResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetLocationQueryResult()
            {
                LocationID = x.LocationID,
                Name = x.Name
            }).ToList();
        }
    }
}
