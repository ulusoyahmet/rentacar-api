using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACarAPI.Application.Features.Mediator.Results.StatisticsResults;
using RentACarAPI.Application.Interfaces.StatisticsInterfaces;

namespace RentACarAPI.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountUnder1000KmQueryHandler:
        IRequestHandler<GetCarCountUnder1000KmQuery, GetCarCountUnder1000KmQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountUnder1000KmQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountUnder1000KmQueryResult> Handle(GetCarCountUnder1000KmQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetCarCountUnder1000KmAsync();
            return new GetCarCountUnder1000KmQueryResult()
            {
                CarCountUnder1000Km = value
            };
        }
    }
}
