using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.TagCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.TagHandlers
{
    public class RemoveTagCommandHandler: IRequestHandler<RemoveTagCommand>
    {
        private readonly IRepository<Tag> _repository;

        public RemoveTagCommandHandler(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTagCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
