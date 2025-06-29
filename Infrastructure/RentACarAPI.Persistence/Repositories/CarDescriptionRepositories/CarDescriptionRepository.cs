using Microsoft.EntityFrameworkCore;
using RentACarAPI.Application.Interfaces.CarDescriptionInterfaces;
using RentACarAPI.Domain.Entities;
using RentACarAPI.Persistence.Context;

namespace RentACarAPI.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository: ICarDescriptionRepository
    {
        private readonly CarBookContext _context;
        private readonly DbSet<CarDescription> _dbSet;

        public CarDescriptionRepository(CarBookContext context)
        {
            _context = context;
            _dbSet = _context.Set<CarDescription>();
        }
        public async Task<CarDescription> GetCarDescriptionByCarId(int id)
        {
            return await _context.CarDescriptions
                .Where(x => x.CarID == id)
                .FirstOrDefaultAsync();
        }
    }
}
