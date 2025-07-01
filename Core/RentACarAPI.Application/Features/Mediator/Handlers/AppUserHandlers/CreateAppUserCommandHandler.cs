using MediatR;
using RentACarAPI.Application.Enums;
using RentACarAPI.Application.Features.Mediator.Commands.AppUserCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler: IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;

        public CreateAppUserCommandHandler(IRepository<AppUser> userRepository)
        {
            _repository = userRepository;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser()
            {
                Password = request.Password,
                Username = request.Username,
                AppRoleID = (int)AppRoleTypes.Member,
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email
            });
        }
    }
}
