using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.TestimonialCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler: IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TestimonialID);

            value.Name = request.Name;
            value.Title = request.Title;
            value.Comment = request.Comment;
            value.ImageUrl = request.ImageUrl;

            await _repository.UpdateAsync(value);
        }
    }
}
