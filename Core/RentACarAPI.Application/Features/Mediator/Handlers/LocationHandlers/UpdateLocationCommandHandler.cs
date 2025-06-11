using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.LocationCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class UpdateLocationCommandHandler: IRequestHandler<UpdateLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public UpdateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.LocationID);
            if (value == null)
            {
                throw new KeyNotFoundException($"Location with {request.LocationID} ID not found.");
            }

            value.Name = request.Name;

            await _repository.UpdateAsync(value);
        }
    }
}
