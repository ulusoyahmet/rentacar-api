using RentACarAPI.Application.Features.CQRS.Queries.CategoryQueries;
using RentACarAPI.Application.Features.CQRS.Results.CategoryResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetCategoryByIdQueryResult()
            {
                CategoryID = value.CategoryID,
                Name = value.Name
            };
        }
    }
}
