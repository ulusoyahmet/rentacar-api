using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.StatisticsResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetCarCountUnder1000KmQuery : IRequest<GetCarCountUnder1000KmQueryResult>
    {
    }
}
