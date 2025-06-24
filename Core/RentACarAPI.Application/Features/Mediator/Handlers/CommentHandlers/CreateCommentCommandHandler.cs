using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.CommentCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Comments.Mediator.Handlers.CommentHandlers
{
    public class CreateCommentCommandHandler: IRequestHandler<CreateCommentCommand>
    {
        private readonly IRepository<Comment> _repository;
        public CreateCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Comment()
            {
                Name = request.Name,
                BlogID = request.BlogID,
                Body = request.Body,
                CreatedDate = DateTime.Now
            });
        }
    }
}
