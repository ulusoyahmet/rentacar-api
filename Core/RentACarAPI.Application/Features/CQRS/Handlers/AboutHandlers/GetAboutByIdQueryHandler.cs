using RentACarAPI.Application.Features.CQRS.Queries.AboutQueries;
using RentACarAPI.Application.Features.CQRS.Results.AboutResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAboutByIdQueryResult()
            {
                AboutID = values.AboutID,
                Title = values.Title,
                Description = values.Description,
                ImageUrl = values.ImageUrl
            };
        }
    }
}
