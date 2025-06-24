using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Application.Features.Mediator.Commands.CommentCommands;
using RentACarAPI.Application.Features.RepositoryPattern;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository; 
        private readonly IMediator _mediator;

        public CommentController(IGenericRepository<Comment> commentRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var values = await _commentRepository.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var value = await _commentRepository.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("GetCommentsByBlog")]
        public async Task<IActionResult> GetCommentsByBlog(int id)
        {
            var values = await _commentRepository.GetCommentsByBlogId(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok($"Comment has been added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
            var value = await _commentRepository.GetByIdAsync(id);
            await _commentRepository.RemoveAsync(value);
            return Ok($"Comment({id}) has been deleted.");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateComment(Comment entity)
        {
            await _commentRepository.UpdateAsync(entity);
            return Ok($"Comment({entity.CommentID}) has been updated");
        }
    }
}
