using MediatR;
using RentACarAPI.Application.Features.Mediator.Commands.CarBookingCommands;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mediator.Handlers.CarBookingHandlers
{
    public class CreateCarBookingCommandHandler: IRequestHandler<CreateCarBookingCommand>
    {
        private readonly IRepository<CarBooking> _repository;

        public CreateCarBookingCommandHandler(IRepository<CarBooking> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarBookingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new CarBooking()
            {
                Name = request.Name,
                Surname = request.Surname,
                Age = request.Age,
                CarID = request.CarID,
                Email = request.Email,
                Phone = request.Phone,
                PickUpLocationID = request.PickUpLocationID,
                DropOffLocationID = request.DropOffLocationID,
                LicenseYear = request.LicenseYear,
                Message = request.Message,
                Status = "Request Received"
            });
        }
    }
}
