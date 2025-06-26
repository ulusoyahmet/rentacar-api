using MediatR;
using RentACarAPI.Application.Features.CQRS.Commands.CarCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Application.Interfaces.CarInterfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        private readonly IRepository<Feature> _featureRepository;
        private readonly IRepository<CarFeature> _carFeatureRepository;

        public CreateCarCommandHandler(
            IRepository<Car> repository,
            IRepository<Feature> featureRepository,
            IRepository<CarFeature> carFeatureRepository)
        {
            _repository = repository;
            _featureRepository = featureRepository;
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            var car = await _repository.CreateAsync(new Car()
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

            var features = await _featureRepository.GetAllAsync();
            foreach (Feature feature in features)
            {
                await _carFeatureRepository.CreateAsync(new CarFeature()
                {
                    CarID = car.CarID,
                    FeatureID = feature.FeatureID,
                    Available = false
                });
            }
        }
    }
}
