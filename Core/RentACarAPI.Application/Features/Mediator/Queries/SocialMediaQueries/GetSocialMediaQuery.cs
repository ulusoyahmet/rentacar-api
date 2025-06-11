using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.SocialMediaResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaQuery : IRequest<List<GetSocialMediaQueryResult>>
    {
    }
}
