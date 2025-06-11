using MediatR;

namespace RentACarAPI.Application.Features.Mediator.Commands.TagCommands
{
    public class CreateTagCommand : IRequest
    {
        public string? Name { get; set; }
        public int BlogID { get; set; }
    }
}
