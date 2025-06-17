using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACarAPI.Application.Features.Mediator.Results.StatisticsResults;
using RentACarAPI.Application.Interfaces.StatisticsInterfaces;

namespace RentACarAPI.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetMostAffordableCarNameQueryHandler:
        IRequestHandler<GetMostAffordableCarNameQuery, GetMostAffordableCarNameQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetMostAffordableCarNameQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetMostAffordableCarNameQueryResult> Handle(GetMostAffordableCarNameQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetMostAffordableCarNameAsync();
            return new GetMostAffordableCarNameQueryResult()
            {
                MostAffordableCarName = value
            };
        }
    }
}
