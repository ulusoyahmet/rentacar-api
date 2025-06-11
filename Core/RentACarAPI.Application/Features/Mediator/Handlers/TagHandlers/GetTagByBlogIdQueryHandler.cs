using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.TagQueries;
using RentACarAPI.Application.Features.Mediator.Results.TagResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.TagHandlers
{
    public class GetTagByBlogIdQueryHandler: IRequestHandler<GetTagByBlogIdQuery, List<GetTagByBlogIdQueryResult>>
    {
        private readonly IRepository<Tag> _repository;

        public GetTagByBlogIdQueryHandler(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagByBlogIdQueryResult>> Handle(GetTagByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllWithIncludeAsync(x => x.Blog);
            return values.Where(x => x.BlogID == request.Id).Select(y => new GetTagByBlogIdQueryResult()
            {
                BlogID = y.BlogID,
                Name = y.Name,
                TagID = y.TagID
            }).ToList();
        }
    }
}
