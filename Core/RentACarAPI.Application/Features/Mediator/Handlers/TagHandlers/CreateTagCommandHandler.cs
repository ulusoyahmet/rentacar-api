using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.TagCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.TagHandlers
{
    public class CreateTagCommandHandler: IRequestHandler<CreateTagCommand>
    {
        private readonly IRepository<Tag> _repository;

        public CreateTagCommandHandler(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Tag()
            {
                BlogID = request.BlogID,
                Name = request.Name
            });
        }
    }
}
