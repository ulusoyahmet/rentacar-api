using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.BlogResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogWithIncludesQuery : IRequest<List<GetBlogWithIncludesQueryResult>>
    {
    }
}
