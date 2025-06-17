using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACarAPI.Application.Features.Mediator.Results.StatisticsResults;
using RentACarAPI.Application.Interfaces.StatisticsInterfaces;

namespace RentACarAPI.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetBlogTitleWithMostCommentsQueryHandler:
        IRequestHandler<GetBlogTitleWithMostCommentsQuery, GetBlogTitleWithMostCommentsQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBlogTitleWithMostCommentsQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogTitleWithMostCommentsQueryResult> Handle(GetBlogTitleWithMostCommentsQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetBlogTitleWithMostCommentsAsync();
            return new GetBlogTitleWithMostCommentsQueryResult()
            {
                BlogTitle = value
            };
        }
    }
}
