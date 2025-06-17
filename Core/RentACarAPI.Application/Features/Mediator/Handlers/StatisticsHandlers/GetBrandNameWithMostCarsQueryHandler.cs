using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACarAPI.Application.Features.Mediator.Results.StatisticsResults;
using RentACarAPI.Application.Interfaces.StatisticsInterfaces;

namespace RentACarAPI.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetBrandNameWithMostCarsQueryHandler : 
        IRequestHandler<GetBrandNameWithMostCarsQuery, GetBrandNameWithMostCarsQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBrandNameWithMostCarsQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandNameWithMostCarsQueryResult> Handle(GetBrandNameWithMostCarsQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetBrandNameWithMostCarsAsync();
            return new GetBrandNameWithMostCarsQueryResult()
            {
                BrandName = value
            };
        }
    }
}
