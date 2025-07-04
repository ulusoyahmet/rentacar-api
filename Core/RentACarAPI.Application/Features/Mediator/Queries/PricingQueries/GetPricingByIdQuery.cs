﻿using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.PricingResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingByIdQuery : IRequest<GetPricingByIdQueryResult>
    {
        public int Id { get; set; }

        public GetPricingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
