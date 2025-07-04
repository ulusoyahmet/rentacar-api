﻿using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACarAPI.Application.Features.Mediator.Results.StatisticsResults;
using RentACarAPI.Application.Interfaces.StatisticsInterfaces;

namespace RentACarAPI.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAutomaticCarCountQueryHandler :
        IRequestHandler<GetAutomaticCarCountQuery, GetAutomaticCarCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAutomaticCarCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAutomaticCarCountQueryResult> Handle(GetAutomaticCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAutomaticCarCountAsync();
            return new GetAutomaticCarCountQueryResult()
            {
                AutomaricCarCount = value
            };
        }
    }
}
