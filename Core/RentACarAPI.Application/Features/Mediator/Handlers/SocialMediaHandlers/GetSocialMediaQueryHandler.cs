﻿using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.SocialMediaQueries;
using RentACarAPI.Application.Features.Mediator.Results.SocialMediaResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetSocialMediaQueryResult()
            {
                SocialMediaID = x.SocialMediaID,
                Name = x.Name,
                Icon = x.Icon,
                Url = x.Url
            }).ToList();
        }
    }
}
