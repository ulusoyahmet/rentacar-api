using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.FooterAddressQueries;
using RentACarAPI.Application.Features.Mediator.Results.FooterAddressResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult()
            {
                FooterAddressID = x.FooterAddressID,
                Description = x.Description,
                Address = x.Address,
                Email = x.Email,
                Phone = x.Phone
            }).ToList();
        }
    }
}
