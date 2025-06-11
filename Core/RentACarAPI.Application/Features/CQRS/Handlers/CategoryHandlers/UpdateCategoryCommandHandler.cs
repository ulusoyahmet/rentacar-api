using RentACarAPI.Application.Features.CQRS.Commands.CategoryCommands;
using RentACarAPI.Application.Features.CQRS.Handlers.AboutHandlers;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CategoryID);
            if (value == null)
            {
                throw new NotFoundException($"Category with ID {command.CategoryID} not found.");
            }

            value.Name = command.Name;

            await _repository.UpdateAsync(value);
        }
    }
}
