using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.BlogQueries;
using RentACarAPI.Application.Features.Mediator.Results.AuthorResults;
using RentACarAPI.Application.Features.Mediator.Results.BlogResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogQueryHandler: IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBlogQueryResult()
            {
                BlogID = x.BlogID,
                AuthorID = x.AuthorID,
                CategoryID = x.CategoryID,
                Title = x.Title,
                Body = x.Body,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate
            }).ToList();
        }
    }
}
