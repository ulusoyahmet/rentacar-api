using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACarAPI.Application.Features.Mediator.Results.StatisticsResults;
using RentACarAPI.Application.Interfaces.StatisticsInterfaces;

namespace RentACarAPI.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAvgDailyRentingPriceQueryHandler:
        IRequestHandler<GetAvgDailyRentingPriceQuery, GetAvgDailyRentingPriceQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgDailyRentingPriceQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgDailyRentingPriceQueryResult> Handle(GetAvgDailyRentingPriceQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAvgDailyRentingPriceAsync();
            return new GetAvgDailyRentingPriceQueryResult()
            {
                AvgDailyPrice = value
            };
        }
    }
}
