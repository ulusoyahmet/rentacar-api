using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.LocationResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationQuery : IRequest<List<GetLocationQueryResult>>
    {
    }
}
