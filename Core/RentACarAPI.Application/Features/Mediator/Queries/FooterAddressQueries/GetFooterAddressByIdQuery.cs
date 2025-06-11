using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.FooterAddressResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressByIdQuery : IRequest<GetFooterAddressByIdQueryResult>
    {
        public int Id { get; set; }

        public GetFooterAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
