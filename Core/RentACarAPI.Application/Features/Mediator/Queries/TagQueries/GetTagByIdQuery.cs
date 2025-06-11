using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.TagResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.TagQueries
{
    public class GetTagByIdQuery : IRequest<GetTagByIdQueryResult>
    {
        public int Id { get; set; }

        public GetTagByIdQuery(int id)
        {
            Id = id;
        }
    }
}
