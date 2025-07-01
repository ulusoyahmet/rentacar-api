using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.AppUserResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.AppUserQueries
{
    public class GetCheckedAppUserQuery : IRequest<GetCheckedAppUserQueryResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
