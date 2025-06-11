using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.ServiceCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler: IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ServiceID);
            if (value == null)
            {
                throw new KeyNotFoundException($"Service with {request.ServiceID} ID not found.");
            }

            value.Title = request.Title;
            value.Description = request.Description;
            value.IconUrl = request.IconUrl;

            await _repository.UpdateAsync(value);
        }
    }
}
