using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.ServiceResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceQuery : IRequest<List<GetServiceQueryResult>>
    {
    }
}
