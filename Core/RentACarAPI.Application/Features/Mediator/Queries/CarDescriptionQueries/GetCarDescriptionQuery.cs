using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.CarDescriptionResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionQuery: IRequest<GetCarDescriptionByCarIdQueryResult>
    {
    }
}
