﻿using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Application.Features.CQRS.Commands.BrandCommands;
using RentACarAPI.Application.Features.CQRS.Handlers.BrandHandlers;
using RentACarAPI.Application.Features.CQRS.Queries.BrandQueries;

namespace RentACarAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController: ControllerBase
    {
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;

        public BrandController(CreateBrandCommandHandler createBrandCommandHandler,
                               GetBrandByIdQueryHandler getBrandByIdQueryHandler,
                               GetBrandQueryHandler getBrandQueryHandler,
                               UpdateBrandCommandHandler updateBrandCommandHandler,
                               RemoveBrandCommandHandler removeBrandCommandHandler)
        {
            _createBrandCommandHandler = createBrandCommandHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            var values = await _getBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var value = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _createBrandCommandHandler.Handle(command);
            return Ok("Brand info has been added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Brand info has been deleted.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handle(command);
            return Ok("Brand info has been updated");
        }
    }
}
