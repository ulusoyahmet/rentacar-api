using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.AuthorResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.AuthorQueries
{
    public class GetAuthorQuery : IRequest<List<GetAuthorQueryResult>>
    {
    }
}
