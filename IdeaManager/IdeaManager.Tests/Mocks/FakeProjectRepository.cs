using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;

namespace IdeaManager.Tests.Mocks
{
    public class FakeProjectRepository : IRepository<Project>
    {
        private readonly List<Project> _projects;
        public FakeProjectRepository()
        {
            _projects = new List<Project>();
        }
        public Task<List<Project>> GetAllAsync()
        {
            return Task.FromResult(_projects);
        }
        public Task<Project?> GetByIdAsync(int id)
        {
            var project = _projects.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(project);
        }
        public Task AddAsync(Project project)
        {
            _projects.Add(project);
            return Task.CompletedTask;
        }
        public Task UpdateAsync(Project project)
        {
            var index = _projects.FindIndex(p => p.Id == project.Id);
            if (index != -1)
            {
                _projects[index] = project;
            }
            return Task.CompletedTask;
        }
        public Task DeleteAsync(int id)
        {
            var project = _projects.FirstOrDefault(p => p.Id == id);
            if (project != null)
            {
                _projects.Remove(project);
            }
            return Task.CompletedTask;
        }
    }
    
}
