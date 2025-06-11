using RentACarAPI.Application.Features.CQRS.Commands.ContactCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class RemoveContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public RemoveContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveContactCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            if (value == null)
            {
                throw new KeyNotFoundException($"Contact with {command.Id} ID not found.");
            }

            await _repository.RemoveAsync(value);
        }
    }
}
