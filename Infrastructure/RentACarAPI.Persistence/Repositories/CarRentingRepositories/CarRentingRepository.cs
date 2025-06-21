using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RentACarAPI.Application.Interfaces.CarRentingInterfaces;
using RentACarAPI.Domain.Entities;
using RentACarAPI.Persistence.Context;

namespace RentACarAPI.Persistence.Repositories.CarRentingRepositories
{
    public class CarRentingRepository: ICarRentingRepository
    {
        private readonly CarBookContext _context;

        public CarRentingRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarRenting>> GetByFilterAsync(Expression<Func<CarRenting, bool>> filter)
        {
            var values = await _context.CarRentings
                .Include(c => c.Car)
                .ThenInclude(b => b.Brand)
                .Include(c => c.Car)
                .ThenInclude(d => d.CarPricings)
                .ThenInclude(c => c.Pricing)
                .Where(filter)
                .ToListAsync();
            return values;
        }
    }
}
