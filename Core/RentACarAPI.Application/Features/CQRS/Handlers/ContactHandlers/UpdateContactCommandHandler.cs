using RentACarAPI.Application.Features.CQRS.Commands.ContactCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var value = await _repository.GetByIdAsync(command.ContactID);
            if (value == null)
            {
                throw new KeyNotFoundException($"Contact with {command.ContactID} ID not found.");
            }

            value.Email = command.Email;
            value.Subject = command.Subject;
            value.Message = command.Message;
            value.Name = command.Name;
            value.SentDate = command.SentDate;

            await _repository.UpdateAsync(value);
        }
    }
}
