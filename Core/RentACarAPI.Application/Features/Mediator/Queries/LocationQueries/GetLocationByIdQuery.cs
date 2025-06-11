using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.LocationResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationByIdQuery: IRequest<GetLocationByIdQueryResult>
    {
        public int Id { get; set; }

        public GetLocationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
