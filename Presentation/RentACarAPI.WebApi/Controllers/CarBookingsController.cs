using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Application.Features.Mediator.Commands.CarBookingCommands;

namespace RentACarAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBookingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarBookingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarBooking(CreateCarBookingCommand command)
        {
            await _mediator.Send(command);
            return Ok($"Car Booking has been added.");
        }
    }
}
