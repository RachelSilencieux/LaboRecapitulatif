using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeaManager.Core.Entities;

namespace IdeaManager.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Idea> IdeaRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Vote> VoteRepository { get; }
        IRepository<Project> ProjectRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
