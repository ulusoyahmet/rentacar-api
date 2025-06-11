using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.BlogResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogQuery : IRequest<List<GetBlogQueryResult>>
    {
    }
}
