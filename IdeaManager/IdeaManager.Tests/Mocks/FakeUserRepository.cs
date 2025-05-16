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
        private readonly List<User> _users = new List<User>();
        public Task AddAsync(User user)
        {
            _users.Add(user);
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
        public Task UpdateAsync(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Email = user.Email;
                existingUser.PasswordHash = user.PasswordHash;
                existingUser.Votes = user.Votes;
            }
            return Task.CompletedTask;
        }
        public Task<User> GetByIdAsync(int id)
        {
            return Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
        }
        public Task<List<User>> GetAllAsync()
        {
            return Task.FromResult(_users);
        }
    }
}
