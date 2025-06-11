using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.TestimonialResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialQuery : IRequest<List<GetTestimonialQueryResult>>
    {
    }
}
