using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Application.Features.Mediator.Commands.CarFeatureCommands;
using RentACarAPI.Application.Features.Mediator.Queries.CarFeatureQueries;

namespace RentACarAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarFeaturesByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarFeatures(List<UpdateCarFeatureByCarIdCommand> commands)
        {
            foreach (var command in commands)
            {
                await _mediator.Send(command);
            }

            return Ok("All car features updated.");
        }

    }
}
