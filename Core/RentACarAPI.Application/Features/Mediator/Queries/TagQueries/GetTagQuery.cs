using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.TagResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.TagQueries
{
    public class GetTagQuery : IRequest<List<GetTagQueryResult>>
    {
    }
}
