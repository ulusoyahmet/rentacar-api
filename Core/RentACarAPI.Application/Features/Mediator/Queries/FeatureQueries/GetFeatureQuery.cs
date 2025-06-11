using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.FeatureResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureQuery : IRequest<List<GetFeatureQueryResult>>
    {
    }
}
