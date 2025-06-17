using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACarAPI.Application.Features.Mediator.Results.StatisticsResults;
using RentACarAPI.Application.Interfaces.StatisticsInterfaces;

namespace RentACarAPI.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetMostExpensiveCarNameQueryHandler:
        IRequestHandler<GetMostExpensiveCarNameQuery, GetMostExpensiveCarNameQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetMostExpensiveCarNameQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetMostExpensiveCarNameQueryResult> Handle(GetMostExpensiveCarNameQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetMostExpensiveCarNameAsync();
            return new GetMostExpensiveCarNameQueryResult()
            {
                MostExpensiveCarName = value
            };
        }
    }
}
