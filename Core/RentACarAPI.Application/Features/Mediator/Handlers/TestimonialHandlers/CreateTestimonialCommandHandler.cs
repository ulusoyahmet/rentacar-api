using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.TestimonialCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler: IRequestHandler<CreateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public CreateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Testimonial()
            {
                Name = request.Name,
                Title = request.Title,
                Comment = request.Comment,
                ImageUrl = request.ImageUrl
            });
        }
    }
}
