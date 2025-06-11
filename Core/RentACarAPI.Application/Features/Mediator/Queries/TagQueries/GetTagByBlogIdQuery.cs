using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.TagResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.TagQueries
{
    public class GetTagByBlogIdQuery : IRequest<List<GetTagByBlogIdQueryResult>>
    {
        public int Id { get; set; }

        public GetTagByBlogIdQuery(int id)
        {
            Id = id;
        }
    }
}
