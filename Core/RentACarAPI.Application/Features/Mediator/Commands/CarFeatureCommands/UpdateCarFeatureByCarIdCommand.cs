using MediatR;

namespace RentACarAPI.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureByCarIdCommand : IRequest
    {
        public int CarFeatureID { get; set; }
        public int CarID { get; set; }
        public int FeatureID { get; set; }
        public bool Available { get; set; }
    }
}
