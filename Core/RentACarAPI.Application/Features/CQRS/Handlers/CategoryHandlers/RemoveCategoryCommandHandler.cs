using RentACarAPI.Application.Features.CQRS.Commands.CategoryCommands;
using RentACarAPI.Application.Features.CQRS.Handlers.AboutHandlers;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            if (value == null)
            {
                throw new NotFoundException($"Category with ID {command.Id} not found.");
            }

            await _repository.RemoveAsync(value);
        }
    }
}
