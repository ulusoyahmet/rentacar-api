using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.PricingCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class CreatePricingCommandHandler: IRequestHandler<CreatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public CreatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Pricing()
            {
                Name = request.Name
            });
        }
    }
}
