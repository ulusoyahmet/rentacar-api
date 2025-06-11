using RentACarAPI.Application.Features.CQRS.Commands.BannerCommands;
using RentACarAPI.Application.Features.CQRS.Handlers.AboutHandlers;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.BannerID);
            if (value == null)
            {
                throw new NotFoundException($"Banner with ID {command.BannerID} not found.");
            }

            value.Title = command.Title;
            value.Description = command.Description;
            value.VideoUrl = command.VideoUrl;
            value.VideoDescription = command.VideoDescription;

            await _repository.UpdateAsync(value);
        }
    }
}
