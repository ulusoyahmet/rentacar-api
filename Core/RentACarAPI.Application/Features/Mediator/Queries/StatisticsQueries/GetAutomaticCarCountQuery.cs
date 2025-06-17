using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.StatisticsResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetAutomaticCarCountQuery 
        : IRequest<GetAutomaticCarCountQueryResult>
    {
    }
}
