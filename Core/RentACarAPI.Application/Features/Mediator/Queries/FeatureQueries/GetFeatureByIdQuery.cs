﻿using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.FeatureResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureByIdQuery : IRequest<GetFeatureByIdQueryResult>
    {
        public int Id { get; set; }

        public GetFeatureByIdQuery(int id)
        {
            Id = id;
        }
    }
}
