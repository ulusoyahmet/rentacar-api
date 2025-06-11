using RentACarAPI.Application.Features.CQRS.Commands.CategoryCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            await _repository.CreateAsync(new Category()
            {
                Name = command.Name
            });
        }
    }
}
