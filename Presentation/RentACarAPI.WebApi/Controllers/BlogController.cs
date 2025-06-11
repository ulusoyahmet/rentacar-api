using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Application.Features.Mediator.Commands.BlogCommands;
using RentACarAPI.Application.Features.Mediator.Queries.BlogQueries;

namespace RentACarAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogWithFields")]
        public async Task<IActionResult> GetBlogWithFields()
        {
            var values = await _mediator.Send(new GetBlogWithIncludesQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok($"Blog has been added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok($"Blog({id}) has been deleted.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok($"Blog({command.BlogID}) has been updated");
        }
    }
}
