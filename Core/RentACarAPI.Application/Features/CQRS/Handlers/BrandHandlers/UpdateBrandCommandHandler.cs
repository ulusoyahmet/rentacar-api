using RentACarAPI.Application.Features.CQRS.Commands.BrandCommands;
using RentACarAPI.Application.Features.CQRS.Handlers.AboutHandlers;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBrandCommand command)
        {
            var value = await _repository.GetByIdAsync(command.BrandID);
            if (value == null)
            {
                throw new NotFoundException($"Banner with ID {command.BrandID} not found.");
            }

            value.Name = command.Name;

            await _repository.UpdateAsync(value);
        }
    }
}
