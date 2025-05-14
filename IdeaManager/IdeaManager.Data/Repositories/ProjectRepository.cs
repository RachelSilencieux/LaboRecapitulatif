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
    public class ProjectRepository : IRepository<Project>
    {
        private readonly IdeaDbContext _context;
        private readonly DbSet<Project> _dbSet;
        public ProjectRepository(IdeaDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Project>();
        }
        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }
        public async Task<Project?> GetByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }
        public async Task AddAsync(Project entity)
        {
            await _context.Projects.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var project = await _dbSet.FindAsync(id);
            if (project != null)
            {
                _dbSet.Remove(project);
                await _context.SaveChangesAsync();
            }
        }
    }
}
