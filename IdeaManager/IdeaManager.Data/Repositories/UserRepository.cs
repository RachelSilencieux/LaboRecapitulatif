using System.Collections.Generic;
using System.Threading.Tasks;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using IdeaManager.Data.Db;
using Microsoft.EntityFrameworkCore;

namespace IdeaManager.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly IdeaDbContext _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(IdeaDbContext context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(User user)
        {
            await _dbSet.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _dbSet.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _dbSet.FindAsync(id);
            if (user != null)
            {
                _dbSet.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
