using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.AppUserQueries;
using RentACarAPI.Application.Features.Mediator.Results.AppUserResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckedAppUserQueryHandler : IRequestHandler<GetCheckedAppUserQuery, GetCheckedAppUserQueryResult>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<AppRole> _roleRepository;

        public GetCheckedAppUserQueryHandler(IRepository<AppUser> userRepository,
            IRepository<AppRole> roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<GetCheckedAppUserQueryResult> Handle(GetCheckedAppUserQuery request, CancellationToken cancellationToken)
        {
            var value = new GetCheckedAppUserQueryResult();
            var user = await _userRepository.GetByFilterAsync(x =>
                x.Username == request.Username && x.Password == x.Password);

            if (user == null)
            {
                value.IsExists = false;
            }
            else
            {
                value.IsExists = true;
                value.Username = user.Username;
                value.Role = (await _roleRepository
                    .GetByFilterAsync(x => x.AppRoleID == user.AppRoleID)).Name;
                value.ID = user.AppUserID;
            }

            return value;
        }
    }
}
