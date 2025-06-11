using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.FooterAddressCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler: IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FooterAddressID);
            if (value == null)
            {
                throw new KeyNotFoundException($"Footer Address with {request.FooterAddressID} ID not found.");
            }

            value.Address = request.Address;
            value.Description = request.Description;
            value.Email = request.Email;
            value.Phone = request.Phone;

            await _repository.UpdateAsync(value);
        }
    }
}
