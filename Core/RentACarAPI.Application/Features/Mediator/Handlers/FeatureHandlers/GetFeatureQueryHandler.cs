﻿using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.FeatureQueries;
using RentACarAPI.Application.Features.Mediator.Results.FeatureResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler: IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;
        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request,
                                            CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFeatureQueryResult()
            {
                FeatureID = x.FeatureID,
                Name = x.Name
            }).ToList();
        }
    }
}
