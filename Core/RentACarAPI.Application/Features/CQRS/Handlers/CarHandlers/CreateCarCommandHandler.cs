using RentACarAPI.Application.Features.CQRS.Commands.CarCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car()
            {
                BrandID = command.BrandID,
                Fuel = command.Fuel,
                CoverImageUrl = command.CoverImageUrl,
                Km = command.Km,
                Luggage = command.Luggage,
                Model = command.Model,
                Seat = command.Seat,
                Transmission = command.Transmission,
                BigImageUrl = command.BigImageUrl
            });
        }
    }
}
