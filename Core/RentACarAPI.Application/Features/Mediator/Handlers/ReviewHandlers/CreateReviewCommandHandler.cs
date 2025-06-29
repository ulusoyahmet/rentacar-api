using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.ReviewCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class CreateReviewCommandHandler: IRequestHandler<CreateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public CreateReviewCommandHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Review()
            {
                CarID = request.CarID,
                CustomerName = request.CustomerName,
                Comment = request.Comment,
                CreatedDate = request.CreatedDate,
                CustomerImage = request.CustomerImage,
                Rating = request.Rating
            });
        }
    }
}
