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
    public class VoteRepository : IRepository<Vote>
    {
        private readonly IdeaDbContext _context;
        private readonly DbSet<Vote> _dbSet;
        public VoteRepository(IdeaDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Vote>();
        }
        public async Task<List<Vote>> GetAllAsync()
        {
            return await _context.Votes.ToListAsync();
        }
        public async Task<Vote?> GetByIdAsync(int id)
        {
            return await _context.Votes.FindAsync(id);
        }
        public async Task AddAsync(Vote entity)
        {
            await _context.Votes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Vote entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var vote = await _dbSet.FindAsync(id);
            if (vote != null)
            {
                _dbSet.Remove(vote);
                await _context.SaveChangesAsync();
            }
        }


    }


}
