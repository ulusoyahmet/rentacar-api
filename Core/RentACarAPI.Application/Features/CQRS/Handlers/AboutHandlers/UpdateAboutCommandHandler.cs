using RentACarAPI.Application.Features.CQRS.Commands.AboutCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAboutCommand command)
        {
            var about = await _repository.GetByIdAsync(command.AboutID);
            if (about == null)
            {
                throw new NotFoundException($"About with ID {command.AboutID} not found.");
            }

            about.Title = command.Title;
            about.Description = command.Description;
            about.ImageUrl = command.ImageUrl;

            await _repository.UpdateAsync(about);
        }

    }
}
