using RentACarAPI.Application.Features.CQRS.Commands.ContactCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateContactCommand command)
        {
            await _repository.CreateAsync(new Contact()
            {
                Email = command.Email,
                Message = command.Message,
                Name = command.Name,
                SentDate = command.SentDate,
                Subject = command.Subject
            });
            
        }
    }
}
