using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using IdeaManager.Data.Repositories;
using IdeaManager.Services.Services;
using IdeaManager.Tests.Mocks;

namespace IdeaManager.Tests;

public class FakeUnitOfWork : IUnitOfWork
{
    public IRepository<Idea> IdeaRepository { get; }
    public IRepository<User> UserRepository { get; }
    public IRepository<Vote> VoteRepository { get; }
    public IRepository<Project> ProjectRepository { get; }

    public FakeUnitOfWork()
    {
        IdeaRepository = new FakeIdeaRepository();
        UserRepository = new FakeUserRepository();
        VoteRepository = new FakeVoteRepository();
        ProjectRepository = new FakeProjectRepository();
    }
    public Task<int> SaveChangesAsync()
    {
        return Task.FromResult(1);
    }

    public void Dispose(){}


}
