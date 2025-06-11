using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.TagQueries;
using RentACarAPI.Application.Features.Mediator.Results.TagResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.TagHandlers
{
    public class GetTagQueryHandler: IRequestHandler<GetTagQuery, List<GetTagQueryResult>>
    {
        private readonly IRepository<Tag> _repository;

        public GetTagQueryHandler(IRepository<Tag> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTagQueryResult()
            {
                BlogID = x.BlogID,
                Name = x.Name,
                TagID = x.TagID
            }).ToList();
        }
    }
}
