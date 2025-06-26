using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.FeatureCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;
        private readonly IRepository<CarFeature> _carFeatureRepository;
        private readonly IRepository<Car> _carRepository;
        public CreateFeatureCommandHandler(
            IRepository<Feature> repository,
            IRepository<CarFeature> carFeatureRepository,
            IRepository<Car> carRepository)
        {
            _repository = repository;
            _carFeatureRepository = carFeatureRepository;
            _carRepository = carRepository;
        }
        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var createdFeature = await _repository.CreateAsync(new Feature()
            {
                Name = request.Name
            });

            var cars = await _carRepository.GetAllAsync();
            foreach (Car car in cars)
            {
                await _carFeatureRepository.CreateAsync(new CarFeature()
                {
                    CarID = car.CarID,
                    FeatureID = createdFeature.FeatureID,
                    Available = false
                });
            }
        }

    }
}
