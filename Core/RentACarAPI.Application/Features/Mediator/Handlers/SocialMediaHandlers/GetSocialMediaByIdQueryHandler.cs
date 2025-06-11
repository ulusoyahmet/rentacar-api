using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.SocialMediaQueries;
using RentACarAPI.Application.Features.Mediator.Results.SocialMediaResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler: IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetSocialMediaByIdQueryResult()
            {
                SocialMediaID = value.SocialMediaID,
                Name = value.Name,
                Icon = value.Icon,
                Url = value.Url
            };
        }
    }
}
