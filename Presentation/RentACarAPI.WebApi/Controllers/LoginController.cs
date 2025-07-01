using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Application.Features.Mediator.Queries.AppUserQueries;
using RentACarAPI.Application.Tools;

namespace RentACarAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(GetCheckedAppUserQuery query)
        {
            var value = await _mediator.Send(query);
            if (value.IsExists)
            {
                return Created("", JwtTokenGenerator.GenerateToken(value));
            }

            return BadRequest("Username or Password is not correct.");
        }
    }
}
