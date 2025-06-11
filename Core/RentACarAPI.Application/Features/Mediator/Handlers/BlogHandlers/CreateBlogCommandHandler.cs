using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.BlogCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class CreateBlogCommandHandler: IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Blog()
            {
                AuthorID = request.AuthorID,
                CategoryID = request.CategoryID,
                Title = request.Title,
                Body = request.Body,
                CoverImageUrl = request.CoverImageUrl,
                CreatedDate = request.CreatedDate
            });
        }
    }
}
