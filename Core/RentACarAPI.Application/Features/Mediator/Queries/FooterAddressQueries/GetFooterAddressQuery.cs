using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.FooterAddressResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressQuery : IRequest<List<GetFooterAddressQueryResult>>
    {
    }
}
