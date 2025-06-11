using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Application.Features.Mediator.Commands.ServiceCommands;
using RentACarAPI.Application.Features.Mediator.Queries.ServiceQueries;

namespace RentACarAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetServicees()
        {
            var values = await _mediator.Send(new GetServiceQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok($"Service has been added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveService(int id)
        {
            await _mediator.Send(new RemoveServiceCommand(id));
            return Ok($"Service({id}) has been deleted.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok($"Service({command.ServiceID}) has been updated");
        }
    }
}
