using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Application.Features.Mediator.Queries.CarPricingQuries;

namespace RentACarAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetCarPricinges()
        //{
        //    var values = await _mediator.Send(new GetCarPricingQuery());
        //    return Ok(values);
        //}

        [HttpGet("GetCarPricingsWithCarDetails")]
        public async Task<IActionResult> GetCarPricingsWithCarDetails()
        {
            var query = new GetCarPricingWithCarQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetCarPricing(int id)
        //{
        //    var value = await _mediator.Send(new GetCarPricingByIdQuery(id));
        //    return Ok(value);
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateCarPricing(CreateCarPricingCommand command)
        //{
        //    await _mediator.Send(command);
        //    return Ok($"CarPricing has been added.");
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> RemoveCarPricing(int id)
        //{
        //    await _mediator.Send(new RemoveCarPricingCommand(id));
        //    return Ok($"CarPricing({id}) has been deleted.");
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateCarPricing(UpdateCarPricingCommand command)
        //{
        //    await _mediator.Send(command);
        //    return Ok($"CarPricing({command.CarPricingID}) has been updated");
        //}
    }
}
