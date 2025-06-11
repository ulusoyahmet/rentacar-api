using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.AuthorQueries;
using RentACarAPI.Application.Features.Mediator.Results.AuthorResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorQueryHandler: IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAuthorQueryResult()
            {
                AuthorID = x.AuthorID,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl
            }).ToList();
        }
    }
}
