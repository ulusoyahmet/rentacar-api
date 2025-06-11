using MediatR;

namespace RentACarAPI.Application.Features.Mediator.Commands.PricingCommands
{
    public class CreatePricingCommand : IRequest
    {
        public string? Name { get; set; }
    }
}
