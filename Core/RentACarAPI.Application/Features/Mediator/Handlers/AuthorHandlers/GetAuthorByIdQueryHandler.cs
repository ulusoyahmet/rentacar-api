using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.AuthorQueries;
using RentACarAPI.Application.Features.Mediator.Results.AuthorResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorByIdQueryHandler: IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorByIdQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }
        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetAuthorByIdQueryResult()
            {
                AuthorID = value.AuthorID,
                Name = value.Name,
                Description = value.Description,
                ImageUrl = value.ImageUrl
            };
        }
    }
}
