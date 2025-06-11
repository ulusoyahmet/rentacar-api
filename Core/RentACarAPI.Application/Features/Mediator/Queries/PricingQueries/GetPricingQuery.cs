using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.PricingResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingQuery : IRequest<List<GetPricingQueryResult>>
    {
    }
}
