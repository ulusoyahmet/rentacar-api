using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACarAPI.Application.Features.Mediator.Results.StatisticsResults;
using RentACarAPI.Application.Interfaces.StatisticsInterfaces;

namespace RentACarAPI.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetElectricCarCountQueryHandler:
        IRequestHandler<GetElectricCarCountQuery, GetElectricCarCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetElectricCarCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetElectricCarCountQueryResult> Handle(GetElectricCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetElectricCarCountAsync();
            return new GetElectricCarCountQueryResult()
            {
                ElectricCarCount = value
            };
        }
    }
}
