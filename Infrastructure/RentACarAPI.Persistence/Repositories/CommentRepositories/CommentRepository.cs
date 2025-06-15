using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RentACarAPI.Application.Features.RepositoryPattern;
using RentACarAPI.Domain.Entities;
using RentACarAPI.Persistence.Context;

namespace RentACarAPI.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarBookContext _context;
        private readonly DbSet<Comment> _dbSet;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
            _dbSet = _context.Set<Comment>();
        }

        public async Task CreateAsync(Comment entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _dbSet.Select(x => new Comment()
            {
                CommentID = x.CommentID,
                BlogID = x.BlogID,
                Name = x.Name,
                Body = x.Body,
                CreatedDate = x.CreatedDate
            }).ToListAsync();
        }

        public async Task<List<Comment>> GetAllWithIncludeAsync(params Expression<Func<Comment, object>>[] includes)
        {
            IQueryable<Comment> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id) ?? throw new
                KeyNotFoundException($"Entity of type {typeof(Comment).Name} with ID {id} was not found.");
        }

        public async Task<List<Comment>> GetCommentsByBlogId(int id)
        {
            return await _dbSet.Where(x => x.BlogID == id).Select(x => new Comment()
            {
                CommentID = x.CommentID,
                BlogID = x.BlogID,
                Name = x.Name,
                Body = x.Body,
                CreatedDate = x.CreatedDate
            }).ToListAsync();
        }

        public async Task RemoveAsync(Comment entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comment entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
