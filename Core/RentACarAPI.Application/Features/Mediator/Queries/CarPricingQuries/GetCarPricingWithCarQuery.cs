using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.CarPricingResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.CarPricingQuries
{
    public class GetCarPricingWithCarQuery: IRequest<List<GetCarPricingWithCarQueryResult>>
    {
        
    }
}
