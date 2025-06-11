using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.PricingCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class RemovePricingCommandHandler: IRequestHandler<RemovePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public RemovePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
