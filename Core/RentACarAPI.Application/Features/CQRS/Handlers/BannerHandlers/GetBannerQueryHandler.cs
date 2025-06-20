﻿using RentACarAPI.Application.Features.CQRS.Results.BannerResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
         
        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBannerQueryResult()
            {
                BannerID = x.BannerID,
                Title = x.Title,
                Description = x.Description,
                VideoUrl = x.VideoUrl,
                VideoDescription = x.VideoDescription
            }).ToList(); 
        }
    }
}
