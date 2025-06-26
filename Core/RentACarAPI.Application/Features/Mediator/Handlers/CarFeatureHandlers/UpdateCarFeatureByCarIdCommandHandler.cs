using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.CarFeatureCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureByCarIdCommandHandler : IRequestHandler<UpdateCarFeatureByCarIdCommand>
    {
        private readonly IRepository<CarFeature> _repository;

        public UpdateCarFeatureByCarIdCommandHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarFeatureByCarIdCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.CarFeatureID);

            value.Available = request.Available;

            await _repository.UpdateAsync(value);
        }
    }
}
