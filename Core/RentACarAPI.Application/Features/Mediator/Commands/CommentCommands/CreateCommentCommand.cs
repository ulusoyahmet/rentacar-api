using MediatR;

namespace RentACarAPI.Application.Features.Mediator.Commands.CommentCommands
{
    public class CreateCommentCommand : IRequest
    {
        public string? Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Email { get; set; }
        public string? Body { get; set; }
        public int BlogID { get; set; }
    }
}
