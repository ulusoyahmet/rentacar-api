using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Application.Features.CQRS.Commands.CarCommands;
using RentACarAPI.Application.Features.CQRS.Handlers.CarHandlers;
using RentACarAPI.Application.Features.CQRS.Queries.CarQueries;
using RentACarAPI.Application.Features.CQRS.Results.CarResults;
using RentACarAPI.Application.Features.Mediator.Queries.StatisticsQueries;

namespace RentACarAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly GetCarWithDeepIncludesQueryHandler _getCarWithIncludesQueryHandler;
        private readonly GetCarWithIncludesByIdQueryHandler _getCarWithIncludesByIdQueryHandler;

        public CarController(CreateCarCommandHandler createCarCommandHandler,
                               GetCarByIdQueryHandler getCarByIdQueryHandler,
                               GetCarQueryHandler getCarQueryHandler,
                               UpdateCarCommandHandler updateCarCommandHandler,
                               RemoveCarCommandHandler removeCarCommandHandler,
                               GetCarWithBrandQueryHandler getCarWithBrandQueryHandler,
                               GetCarWithDeepIncludesQueryHandler getCarWithIncludesQueryHandler,
                               GetCarWithIncludesByIdQueryHandler getCarWithIncludesByIdQueryHandler)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getCarWithIncludesQueryHandler = getCarWithIncludesQueryHandler;
            _getCarWithIncludesByIdQueryHandler = getCarWithIncludesByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetCarsWithBrand")]
        public async Task<IActionResult> GetCarsWithBrand()
        {
            var values = await _getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetCarsWithIncludes")]
        public async Task<IActionResult> GetCarsWithIncludes()
        {
            var values = await _getCarWithIncludesQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetCarsWithIncludesById")]
        public async Task<IActionResult> GetCarsWithIncludesById(int id)
        {
            var values = await _getCarWithIncludesByIdQueryHandler.Handle(new GetCarWithIncludesByIdQuery(id));
            return Ok(values);
        }

        [HttpGet("GetLast5CarsWithBrand")]
        public async Task<IActionResult> GetLast5CarsWithBrand()
        {
            var values = await _getCarWithBrandQueryHandler.Handle();
            var last5 = values
                .OrderByDescending(x => x.CarID)
                .Take(5)
                .ToList();
            return Ok(last5);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Car info has been added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Car info has been deleted.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Car info has been updated");
        }
    }
}
