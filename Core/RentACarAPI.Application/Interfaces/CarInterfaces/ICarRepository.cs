using System.Linq.Expressions;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllWithIncludeAsync(params Expression<Func<Car, object>>[] includes);

    }
}
