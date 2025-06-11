﻿using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.PricingQueries;
using RentACarAPI.Application.Features.Mediator.Results.PricingResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingByIdQueryHandler: IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetPricingByIdQueryResult()
            {
                PricingID = value.PricingID,
                Name = value.Name
            };
        }
    }
}
