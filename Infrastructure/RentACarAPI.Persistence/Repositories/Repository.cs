using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Persistence.Context;

namespace RentACarAPI.Persistence.Repositories
{
    public class Repository<T>: IRepository<T> where T : class
    {
        private readonly CarBookContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(CarBookContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>> GetAllWithExplicitIncludeAsync(Func<IQueryable<T>, IQueryable<T>> includeFunc)
        {
            IQueryable<T> query = _dbSet.AsQueryable();
            if (includeFunc != null)
            {
                query = includeFunc(query);
            }
            return await query.ToListAsync();
        }

        public async Task<List<T>> GetAllWithIncludeAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<List<T>> GetAllWithDeepIncludeAsync(params string[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id) ?? throw new
                KeyNotFoundException($"Entity of type {typeof(T).Name} with ID {id} was not found.");

        }

        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _dbSet.CountAsync();
        }
    }
}
