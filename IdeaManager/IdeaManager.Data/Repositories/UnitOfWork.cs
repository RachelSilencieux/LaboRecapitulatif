using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using IdeaManager.Data.Db;

namespace IdeaManager.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdeaDbContext _context;
        
        public IRepository<Idea> IdeaRepository { get; }
        public IRepository<User> UserRepository { get; }
        public IRepository<Vote> VoteRepository { get; }
        public IRepository<Project> ProjectRepository { get; }

        public UnitOfWork(IdeaDbContext context, IRepository<Idea> ideaRepository, IRepository<User> userRepository, IRepository<Vote> voteRepository, IRepository<Project> projectRepository)
        {
            _context = context;
            IdeaRepository = ideaRepository;
            UserRepository = userRepository;
            VoteRepository = voteRepository;
            ProjectRepository = projectRepository;

        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
