using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;

namespace IdeaManager.Tests;

public class FakeIdeaRepository : IRepository<Idea>
{
    private readonly List<Idea> _ideas = new List<Idea>();
    public Task AddAsync(Idea idea)
    {
        _ideas.Add(idea);
        return Task.CompletedTask;
    }
    
    public Task DeleteAsync(int id)
    {
        var idea = _ideas.FirstOrDefault(i => i.Id == id);

        if (idea != null)
        {
            _ideas.Remove(idea);
        }
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Idea idea)
    {
        var existingIdea = _ideas.FirstOrDefault(i => i.Id == idea.Id);

        if (existingIdea != null)
        {
            existingIdea.Title = idea.Title;
            existingIdea.Description = idea.Description;
            existingIdea.VotesCount = idea.VotesCount;
            existingIdea.Status = idea.Status;
        }
        return Task.CompletedTask;
    }
    public Task<Idea> GetByIdAsync(int id)
    {
        return Task.FromResult(new Idea());
    }
    public Task<List<Idea>> GetAllAsync()
    {
        return Task.FromResult(new List<Idea>());
    }
    
}

