using RentACarAPI.Application.Features.CQRS.Commands.BannerCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBannerCommand command)
        {
            await _repository.CreateAsync(new Banner()
            {
                Title = command.Title,
                Description = command.Description,
                VideoUrl = command.VideoUrl,
                VideoDescription = command.VideoDescription
            });
            
        }
    }
}
