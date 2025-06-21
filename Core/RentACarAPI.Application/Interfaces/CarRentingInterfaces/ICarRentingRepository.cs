using System.Linq.Expressions;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Interfaces.CarRentingInterfaces
{
    public interface ICarRentingRepository
    {
        Task<List<CarRenting>> GetByFilterAsync(Expression<Func<CarRenting, bool>> filter);
    }
}
