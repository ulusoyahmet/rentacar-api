using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.ReviewCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class UpdateReviewCommandHandler: IRequestHandler<UpdateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public UpdateReviewCommandHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ReviewID);

            value.CustomerName = request.CustomerName;
            value.Comment = request.Comment;
            value.CustomerImage = request.CustomerImage;
            value.Rating = request.Rating;

            await _repository.UpdateAsync(value);
        }
    }
}
