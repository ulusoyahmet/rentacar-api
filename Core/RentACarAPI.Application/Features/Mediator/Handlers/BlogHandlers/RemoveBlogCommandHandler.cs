using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.BlogCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class RemoveBlogCommandHandler: IRequestHandler<RemoveBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public RemoveBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
