using MediatR;

namespace RentACarAPI.Application.Features.Mediator.Commands.TagCommands
{
    public class UpdateTagCommand : IRequest
    {
        public int TagID { get; set; }
        public string? Name { get; set; }
        public int BlogID { get; set; }
    }
}
