using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.BlogQueries;
using RentACarAPI.Application.Features.Mediator.Results.BlogResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogWithIncludesQueryHandler: IRequestHandler<GetBlogWithIncludesQuery, List<GetBlogWithIncludesQueryResult>>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogWithIncludesQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogWithIncludesQueryResult>> Handle(GetBlogWithIncludesQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllWithIncludeAsync(x => x.Author, x => x.Category);
            return values.Select(x => new GetBlogWithIncludesQueryResult()
            {
                BlogID = x.BlogID,
                AuthorID = x.AuthorID,
                AuthorName = x.Author?.Name,
                AuthorDesription = x.Author?.Description,
                AuthorImageUrl = x.Author?.ImageUrl,
                CategoryID = x.CategoryID,
                CategoryName = x.Category?.Name,
                Title = x.Title,
                Body = x.Body,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate
            }).ToList();
        }

    }
}
