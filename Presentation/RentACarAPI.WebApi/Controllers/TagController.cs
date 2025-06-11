using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Application.Features.Mediator.Commands.TagCommands;
using RentACarAPI.Application.Features.Mediator.Queries.TagQueries;

namespace RentACarAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            var values = await _mediator.Send(new GetTagQuery());
            return Ok(values);
        }

        [HttpGet("GetTagsByBlogId")]
        public async Task<IActionResult> GetTagsByBlogId(int id)
        {
            var values = await _mediator.Send(new GetTagByBlogIdQuery(id));
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTag(int id)
        {
            var value = await _mediator.Send(new GetTagByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagCommand command)
        {
            await _mediator.Send(command);
            return Ok($"Tag has been added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTag(int id)
        {
            await _mediator.Send(new RemoveTagCommand(id));
            return Ok($"Tag({id}) has been deleted.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTag(UpdateTagCommand command)
        {
            await _mediator.Send(command);
            return Ok($"Tag({command.TagID}) has been updated");
        }
    }
}
