using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.TagCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.TagHandlers
{
    public class UpdateTagCommandHandler: IRequestHandler<UpdateTagCommand>
    {
        private readonly IRepository<Tag> _repository;

        public UpdateTagCommandHandler(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TagID);

            value.BlogID = request.BlogID;
            value.Name = request.Name;

            await _repository.UpdateAsync(value);
        }
    }
}
