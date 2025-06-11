using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.PricingCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public UpdatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.PricingID);
            if (value == null)
            {
                throw new KeyNotFoundException($"Pricing with {request.PricingID} ID not found.");
            }

            value.Name = request.Name;

            await _repository.UpdateAsync(value);
        }
    }
}
