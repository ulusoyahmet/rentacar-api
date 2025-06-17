using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACarAPI.Application.Features.Mediator.Results.StatisticsResults;
using RentACarAPI.Application.Interfaces.StatisticsInterfaces;

namespace RentACarAPI.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAvgHourlyRentingPriceQueryHandler:
        IRequestHandler<GetAvgHourlyRentingPriceQuery, GetAvgHourlyRentingPriceQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgHourlyRentingPriceQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgHourlyRentingPriceQueryResult> Handle(GetAvgHourlyRentingPriceQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAvgHourlyRentingPriceAsync();
            return new GetAvgHourlyRentingPriceQueryResult()
            {
                AvgHourlyPrice = value
            };
        }
    }
}
