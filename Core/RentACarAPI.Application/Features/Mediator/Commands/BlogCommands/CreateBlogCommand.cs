using MediatR;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Commands.BlogCommands
{
    public class CreateBlogCommand : IRequest
    {
        public string? Title { get; set; }
        public string? Body { get; set; }
        public int AuthorID { get; set; }
        public string? CoverImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CategoryID { get; set; }
    }
}
