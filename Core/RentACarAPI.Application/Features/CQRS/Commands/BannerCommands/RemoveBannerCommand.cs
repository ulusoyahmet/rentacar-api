namespace RentACarAPI.Application.Features.CQRS.Commands.BannerCommands
{
    public class RemoveBannerCommand
    {
        public int Id { get; set; }

        public RemoveBannerCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
