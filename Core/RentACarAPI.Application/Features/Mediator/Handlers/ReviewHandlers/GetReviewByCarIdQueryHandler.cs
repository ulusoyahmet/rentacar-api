using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.ReviewQueries;
using RentACarAPI.Application.Features.Mediator.Results.ReviewResults;
using RentACarAPI.Application.Interfaces.ReviewInterfaces;

namespace RentACarAPI.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByCarIdQueryHandler: IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        private readonly IReviewRepository _repository;
        public GetReviewByCarIdQueryHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarReviewsByCarId(request.Id);
            return values.Select(x => new GetReviewByCarIdQueryResult()
            {
                ReviewID = x.ReviewID,
                CarID = x.CarID,
                CustomerName = x.CustomerName,
                Comment = x.Comment,
                CreatedDate = x.CreatedDate,
                CustomerImage = x.CustomerImage,
                Rating = x.Rating
            }).ToList();
        }
    }
}
