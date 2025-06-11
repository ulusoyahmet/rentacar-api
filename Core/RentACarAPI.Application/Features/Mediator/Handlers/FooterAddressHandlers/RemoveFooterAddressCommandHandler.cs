using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.FooterAddressCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.FooterAddressHandlers
{

    public class RemoveFooterAddressCommandHandler: IRequestHandler<RemoveFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public RemoveFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            await _repository.RemoveAsync(value);
        }
    }
}
