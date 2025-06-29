using Microsoft.EntityFrameworkCore;
using RentACarAPI.Application.Interfaces.ReviewInterfaces;
using RentACarAPI.Domain.Entities;
using RentACarAPI.Persistence.Context;

namespace RentACarAPI.Persistence.Repositories.ReviewRepositories
{
    public class ReviewRepository: IReviewRepository
    {
        private readonly CarBookContext _context;
        private readonly DbSet<Review> _dbSet;

        public ReviewRepository(CarBookContext context)
        {
            _context = context;
            _dbSet = _context.Set<Review>();
        }

        public async Task<List<Review>> GetCarReviewsByCarId(int id)
        {
            return await _context.Reviews.Where(x => x.CarID == id).ToListAsync();
        }
    }
}
