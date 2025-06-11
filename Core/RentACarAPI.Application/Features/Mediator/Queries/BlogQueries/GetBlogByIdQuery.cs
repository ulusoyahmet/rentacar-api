using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.BlogResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByIdQuery : IRequest<GetBlogByIdQueryResult>
    {
        public int Id { get; set; }

        public GetBlogByIdQuery(int id)
        {
            Id = id;
        }
    }
}
