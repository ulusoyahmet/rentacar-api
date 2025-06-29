using System.ComponentModel.DataAnnotations;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Application.Features.Mediator.Commands.ReviewCommands;
using RentACarAPI.Application.Features.Mediator.Queries.ReviewQueries;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarReviewsByCarId(int id)
        {
            var value = await _mediator.Send(new GetReviewByCarIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewCommand command,
            IValidator<CreateReviewCommand> validator)
        {
            var validationResult = await validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(string.Join("\n", validationResult.Errors));
            }

            await _mediator.Send(command);
            return Ok($"Review has been created.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand command,
            IValidator<UpdateReviewCommand> validator)
        {
            var validationResult = await validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(string.Join("\n", validationResult.Errors));
            }
            await _mediator.Send(command);
            return Ok($"Review({command.ReviewID}) has been updated");
        }
    }
}
