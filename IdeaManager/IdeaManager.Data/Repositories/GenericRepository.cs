
using IdeaManager.Core.Interfaces;
using IdeaManager.Data.Db;
using Microsoft.EntityFrameworkCore;

namespace IdeaManager.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly IdeaDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(IdeaDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task UpdateAsync(T id)
        {
            _dbSet.Update(id);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddAsync(T id)
        {
            await _dbSet.AddAsync(id);
            await _context.SaveChangesAsync();
        }

    }
}
