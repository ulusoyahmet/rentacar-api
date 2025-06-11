using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.FooterAddressQueries;
using RentACarAPI.Application.Features.Mediator.Results.FooterAddressResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler: IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetFooterAddressByIdQueryResult()
            {
                FooterAddressID = value.FooterAddressID,
                Description = value.Description,
                Address = value.Address,
                Email = value.Email,
                Phone = value.Phone 
            };
        }
    }
}
