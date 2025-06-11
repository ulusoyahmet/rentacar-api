using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.BlogQueries;
using RentACarAPI.Application.Features.Mediator.Results.BlogResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetBlogByIdQueryResult()
            {
                BlogID = value.BlogID,
                AuthorID = value.AuthorID,
                CategoryID = value.CategoryID,
                Title = value.Title,
                Body = value.Body,
                CoverImageUrl = value.CoverImageUrl,
                CreatedDate = value.CreatedDate
            };
        }
    }
}
