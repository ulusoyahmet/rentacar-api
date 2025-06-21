using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.CarRentingResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.CarRentingQueries
{
    public class GetCarRentingQuery : IRequest<List<GetCarRentingQueryResult>>
    {
        public int LocationID { get; set; }
        public bool Available { get; set; }
    }
}
