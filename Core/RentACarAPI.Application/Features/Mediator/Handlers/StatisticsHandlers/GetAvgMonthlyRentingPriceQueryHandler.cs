using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACarAPI.Application.Features.Mediator.Results.StatisticsResults;
using RentACarAPI.Application.Interfaces.StatisticsInterfaces;

namespace RentACarAPI.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAvgMonthlyRentingPriceQueryHandler:
        IRequestHandler<GetAvgMonthlyRentingPriceQuery, GetAvgMonthlyRentingPriceQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgMonthlyRentingPriceQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgMonthlyRentingPriceQueryResult> Handle(GetAvgMonthlyRentingPriceQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAvgMonthlyRentingPriceAsync();
            return new GetAvgMonthlyRentingPriceQueryResult()
            {
                AvgMonthlyPrice = value
            };
        }
    }
}
