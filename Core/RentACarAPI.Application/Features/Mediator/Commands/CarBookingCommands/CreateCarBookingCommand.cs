using MediatR;

namespace RentACarAPI.Application.Features.Mediator.Commands.CarBookingCommands
{
    public class CreateCarBookingCommand : IRequest
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int CarID { get; set; }
        public int PickUpLocationID { get; set; }
        public int DropOffLocationID { get; set; }
        public int Age { get; set; }
        public int LicenseYear { get; set; }
        public string Message { get; set; }
    }
}
