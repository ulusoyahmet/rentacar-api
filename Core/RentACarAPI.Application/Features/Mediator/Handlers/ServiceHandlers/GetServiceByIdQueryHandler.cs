using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.ServiceQueries;
using RentACarAPI.Application.Features.Mediator.Results.ServiceResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler: IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }
        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetServiceByIdQueryResult()
            {
                ServiceID = value.ServiceID,
                Title = value.Title,
                Description = value.Description,
                IconUrl = value.IconUrl
            };
        }
    }
}
