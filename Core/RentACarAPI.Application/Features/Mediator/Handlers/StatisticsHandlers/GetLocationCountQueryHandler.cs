using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACarAPI.Application.Features.Mediator.Results.StatisticsResults;
using RentACarAPI.Application.Interfaces.StatisticsInterfaces;

namespace RentACarAPI.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetLocationCountQueryHandler:
        IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetLocationCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetLocationCountAsync();
            return new GetLocationCountQueryResult()
            {
                LocationCount = value
            };
        }
    }
}
