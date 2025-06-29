using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Interfaces.CarDescriptionInterfaces
{
    public interface ICarDescriptionRepository
    {
        Task<CarDescription> GetCarDescriptionByCarId(int id);
    }
}
