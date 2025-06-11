using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Application.Features.Mediator.Commands.FooterAddressCommands;
using RentACarAPI.Application.Features.Mediator.Queries.FooterAddressQueries;

namespace RentACarAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFooterAddresses()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddress(int id)
        {
            var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok($"Footer Address has been added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok($"Footer Address({id}) has been deleted.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok($"Footer Address({command.FooterAddressID}) has been updated");
        }
    }
}
