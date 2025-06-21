using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Application.Features.Mediator.Queries.CarRentingQueries;

namespace RentACarAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRentingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarRentingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //public async Task<IActionResult> GetRentACarListByLocation([FromQuery] GetCarRentingQuery query)
        //{
        //    var values = await _mediator.Send(query);
        //    return Ok(values);
        //}

        [HttpGet]
        public async Task<IActionResult> GetCarRentingByLocation(int locationID, bool available)
        {
            GetCarRentingQuery query = new GetCarRentingQuery()
            {
                LocationID = locationID,
                Available = available
            };
            var values = await _mediator.Send(query);
            return Ok(values);
        }

    }
}
