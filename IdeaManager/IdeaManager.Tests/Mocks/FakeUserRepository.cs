using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;

namespace IdeaManager.Tests.Mocks
{
    public class FakeUserRepository : IRepository<User>
    {
        private readonly List<User> _users;

        public FakeUserRepository()
        {
            _users = new List<User>();
        }
        public Task<List<User>> GetAllAsync()
        {
            return Task.FromResult(_users);
        }
        public Task<User?> GetByIdAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return Task.FromResult(user);
        }
        public Task AddAsync(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;
        }
        public Task UpdateAsync(User user)
        {
            var index = _users.FindIndex(u => u.Id == user.Id);
            if (index != -1)
            {
                _users[index] = user;
            }
            return Task.CompletedTask;
        }
        public Task DeleteAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
            return Task.CompletedTask;
        }
    }
}
