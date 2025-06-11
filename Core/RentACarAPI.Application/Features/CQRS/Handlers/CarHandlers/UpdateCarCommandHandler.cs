using RentACarAPI.Application.Features.CQRS.Commands.BrandCommands;
using RentACarAPI.Application.Features.CQRS.Commands.CarCommands;
using RentACarAPI.Application.Features.CQRS.Handlers.AboutHandlers;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarID);
            if (value == null)
            {
                throw new NotFoundException($"Banner with ID {command.CarID} not found.");
            }

            value.BrandID = command.BrandID;
            value.Transmission = command.Transmission;
            value.BigImageUrl = command.BigImageUrl;
            value.Luggage = command.Luggage;
            value.Seat = command.Seat;
            value.CoverImageUrl = command.CoverImageUrl;
            value.Km = command.Km;
            value.Fuel = command.Fuel;
            value.Model = command.Model;

            await _repository.UpdateAsync(value);
        }
    }
}
