using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.FeatureCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;
        public CreateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Feature()
            {
                Name = request.Name
            });
        }
    }
}
