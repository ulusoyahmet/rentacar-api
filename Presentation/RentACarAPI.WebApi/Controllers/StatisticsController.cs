using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Application.Features.Mediator.Queries.StatisticsQueries;

namespace RentACarAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var value = await _mediator.Send(new GetCarCountQuery());
            return Ok(value);
        }

        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var value = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(value);
        }

        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var value = await _mediator.Send(new GetBlogCountQuery());
            return Ok(value);
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var value = await _mediator.Send(new GetBrandCountQuery());
            return Ok(value);
        }

        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocaitonCount()
        {
            var value = await _mediator.Send(new GetLocationCountQuery());
            return Ok(value);
        }

        [HttpGet("GetBrandNameWithMostCars")]
        public async Task<IActionResult> GetBrandNameWithMostCars()
        {
            var value = await _mediator.Send(new GetBrandNameWithMostCarsQuery());
            return Ok(value);
        }

        [HttpGet("GetBlogTitleWithMostComments")]
        public async Task<IActionResult> GetBlogTitleWithMostComments()
        {
            var value = await _mediator.Send(new GetBlogTitleWithMostCommentsQuery());
            return Ok(value);
        }

        [HttpGet("GetAutomaticCarCount")]
        public async Task<IActionResult> GetAutomaticCarCount()
        {
            var value = await _mediator.Send(new GetAutomaticCarCountQuery());
            return Ok(value);
        }

        [HttpGet("GetCarCountUnder1000Km")]
        public async Task<IActionResult> GetCarCountUnder1000Km()
        {
            var value = await _mediator.Send(new GetCarCountUnder1000KmQuery());
            return Ok(value);
        }

        [HttpGet("GetAvgDailyRentingPrice")]
        public async Task<IActionResult> GetAvgDailyRentingPrice()
        {
            var value = await _mediator.Send(new GetAvgDailyRentingPriceQuery());
            return Ok(value);
        }

        [HttpGet("GetAvgHourlyRentingPrice")]
        public async Task<IActionResult> GetAvgHourlyRentingPrice()
        {
            var value = await _mediator.Send(new GetAvgHourlyRentingPriceQuery());
            return Ok(value);
        }

        [HttpGet("GetAvgMonthlyRentingPrice")]
        public async Task<IActionResult> GetAvgMonthlyRentingPrice()
        {
            var value = await _mediator.Send(new GetAvgMonthlyRentingPriceQuery());
            return Ok(value);
        }

        [HttpGet("GetElectricCarCount")]
        public async Task<IActionResult> GetElectricCarCount()
        {
            var value = await _mediator.Send(new GetElectricCarCountQuery());
            return Ok(value);
        }

        [HttpGet("GetDieselOrGasolineCarCount")]
        public async Task<IActionResult> GetDieselOrGasolineCarCount()
        {
            var value = await _mediator.Send(new GetDieselOrGasolineCarCountQuery());
            return Ok(value);
        }

        [HttpGet("GetMostAffordableCarName")]
        public async Task<IActionResult> GetMostAffordableCarName()
        {
            var value = await _mediator.Send(new GetMostAffordableCarNameQuery());
            return Ok(value);
        }

        [HttpGet("GetMostExpensiveCarName")]
        public async Task<IActionResult> GetMostExpensiveCarName()
        {
            var value = await _mediator.Send(new GetMostExpensiveCarNameQuery());
            return Ok(value);
        }
    }
}
