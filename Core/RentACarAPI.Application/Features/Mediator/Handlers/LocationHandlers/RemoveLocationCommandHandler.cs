using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.LocationCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class RemoveLocationCommandHandler: IRequestHandler<RemoveLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public RemoveLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            await _repository.RemoveAsync(value);
        }
    }
}
