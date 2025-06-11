using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.TestimonialQueries;
using RentACarAPI.Application.Features.Mediator.Results.TestimonialResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler: IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTestimonialQueryResult()
            {
                TestimonialID = x.TestimonialID,
                Name = x.Name,
                Title = x.Title,
                Comment = x.Comment,
                ImageUrl = x.ImageUrl
            }).ToList();
        }
    }
}
