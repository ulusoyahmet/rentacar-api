using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.TestimonialQueries;
using RentACarAPI.Application.Features.Mediator.Results.TestimonialResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return  new GetTestimonialByIdQueryResult()
            {
                TestimonialID = value.TestimonialID,
                Name = value.Name,
                Title = value.Title,
                Comment = value.Comment,
                ImageUrl = value.ImageUrl
            };
        }
    }
}
