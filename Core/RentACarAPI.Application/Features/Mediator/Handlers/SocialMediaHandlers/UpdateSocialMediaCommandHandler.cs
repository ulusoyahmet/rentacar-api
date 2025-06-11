﻿using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.SocialMediaCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler: IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.SocialMediaID);
            if (value == null)
            {
                throw new KeyNotFoundException($"Social Media with {request.SocialMediaID} not found.");
            }

            value.Name = request.Name;
            value.Url = request.Url;
            value.Icon = request.Icon;

            await _repository.UpdateAsync(value);
        }
    }
}
