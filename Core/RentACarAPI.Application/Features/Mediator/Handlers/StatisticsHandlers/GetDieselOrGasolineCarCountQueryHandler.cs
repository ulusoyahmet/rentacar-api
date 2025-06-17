using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACarAPI.Application.Features.Mediator.Results.StatisticsResults;
using RentACarAPI.Application.Interfaces.StatisticsInterfaces;

namespace RentACarAPI.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetDieselOrGasolineCarCountQueryHandler:
        IRequestHandler<GetDieselOrGasolineCarCountQuery, GetDieselOrGasolineCarCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetDieselOrGasolineCarCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetDieselOrGasolineCarCountQueryResult> Handle(GetDieselOrGasolineCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetDieselOrGasolineCarCountAsync();
            return new GetDieselOrGasolineCarCountQueryResult()
            {
                IntCombCarCount = value
            };
        }
    }
}
