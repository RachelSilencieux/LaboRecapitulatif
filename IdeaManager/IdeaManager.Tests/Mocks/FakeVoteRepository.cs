using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;

namespace IdeaManager.Tests.Mocks
{
    public class FakeVoteRepository : IRepository<Vote>
    {
        public Task AddAsync(Vote vote)
        {
            return Task.CompletedTask;
        }
        public Task DeleteAsync(int id)
        {
            return Task.CompletedTask;
        }
        public Task<List<Vote>> GetAllAsync()
        {
            return Task.FromResult(new List<Vote>());
        }
        public Task<Vote?> GetByIdAsync(int id)
        {
            return Task.FromResult<Vote?>(null);
        }
        public Task UpdateAsync(Vote vote)
        {
            return Task.CompletedTask;
        }
    }
}
