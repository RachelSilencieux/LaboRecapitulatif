using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using IdeaManager.Data.Db;
using Microsoft.EntityFrameworkCore;

namespace IdeaManager.Data.Repositories
{
    public class IdeaRepository : IRepository<Idea>
    {
        private readonly IdeaDbContext _context;

        private readonly DbSet<Idea> _dbSet;

        public IdeaRepository(IdeaDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Idea>();
        }

        public async Task<List<Idea>> GetAllAsync()
        {
            return await _context.Ideas
                .Include(i => i.Votes)
                .ToListAsync();
        }

        public async Task<Idea?> GetByIdAsync(int id)
        {
            return await _context.Ideas.FindAsync(id);
        }

        public async Task AddAsync(Idea idea)
        {
            _context.Ideas.Add(idea);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Idea idea)
        {
            _context.Ideas.Update(idea);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var idea = await _dbSet.FindAsync(id);
            if (idea != null)
            {
                _dbSet.Remove(idea);
                await _context.SaveChangesAsync();
            }
        }
    }
}
