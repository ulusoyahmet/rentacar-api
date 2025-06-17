using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACarAPI.Application.Features.Mediator.Results.StatisticsResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountQueryHandler: IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
    {
        private readonly IRepository<Car> _repository;

        public GetCarCountQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetCountAsync();
            return new GetCarCountQueryResult()
            {
                CarCount = value
            };
        }
    }
}
