using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.TagQueries;
using RentACarAPI.Application.Features.Mediator.Results.TagResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.TagHandlers
{
    public class GetTagByIdQueryHandler: IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult>
    {
        private readonly IRepository<Tag> _repository;

        public GetTagByIdQueryHandler(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetTagByIdQueryResult()
            {
                BlogID = value.BlogID,
                Name = value.Name,
                TagID = value.TagID
            };
        }
    }
}
