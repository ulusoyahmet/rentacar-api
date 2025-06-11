using Microsoft.EntityFrameworkCore;
using RentACarAPI.Domain.Entities;
using RentACarAPI.Persistence.Context;
using System.Linq.Expressions;

namespace RentACarAPI.Persistence.Repositories.CarRepositories
{
    public class CarRepository
    {
        private readonly CarBookContext _context;
        private readonly DbSet<Car> _dbSet;

        public CarRepository(CarBookContext context)
        {
            _context = context;
            _dbSet = _context.Set<Car>();
        }
        public async Task<List<Car>> GetAllWithIncludeAsync(params Expression<Func<Car, object>>[] includes)
        {
            IQueryable<Car> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }
    }
}
