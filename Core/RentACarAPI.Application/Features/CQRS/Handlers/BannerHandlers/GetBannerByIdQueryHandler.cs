using RentACarAPI.Application.Features.CQRS.Queries.BannerQueries;
using RentACarAPI.Application.Features.CQRS.Results.BannerResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetBannerByIdQueryResult()
            {
                BannerID = value.BannerID,
                Title = value.Title,
                Description = value.Description,
                VideoUrl = value.VideoUrl,
                VideoDescription = value.VideoDescription
            };
        }
    }
}
