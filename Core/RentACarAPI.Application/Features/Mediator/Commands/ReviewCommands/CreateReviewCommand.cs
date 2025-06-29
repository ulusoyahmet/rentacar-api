using MediatR;

namespace RentACarAPI.Application.Features.Mediator.Commands.ReviewCommands
{
    public class CreateReviewCommand : IRequest
    {
        public string? CustomerName { get; set; }
        public string CustomerImage { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public int CarID { get; set; }
    }
}
