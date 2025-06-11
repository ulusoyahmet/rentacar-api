using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.BlogCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler: IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogID);

            value.AuthorID = request.AuthorID;
            value.CategoryID = request.CategoryID;
            value.Title = request.Title;
            value.Body = request.Body;
            value.CoverImageUrl = request.CoverImageUrl;
            value.CreatedDate = request.CreatedDate;

            await _repository.UpdateAsync(value);
        }
    }
}
