using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.CarDescriptionResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionByCarIdQuery : IRequest<GetCarDescriptionByCarIdQueryResult>
    {
        public int Id { get; set; }

        public GetCarDescriptionByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
