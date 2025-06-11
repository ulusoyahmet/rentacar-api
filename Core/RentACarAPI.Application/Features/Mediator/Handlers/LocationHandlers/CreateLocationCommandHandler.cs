using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.LocationCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class CreateLocationCommandHandler: IRequestHandler<CreateLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public CreateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Location()
            {
                Name = request.Name
            });
        }
    }
}
