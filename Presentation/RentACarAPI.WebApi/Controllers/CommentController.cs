using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Application.Features.RepositoryPattern;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public CommentController(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
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

        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment entity)
        {
            await _commentRepository.CreateAsync(entity);
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
