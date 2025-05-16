using IdeaManager.Core.Entities;
using IdeaManager.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace IdeaManager.Tests;

public class IdeaServiceTests
{
    [Fact]
    public async Task AddIdea_Test()
    {
        var fakeRepoIdea = new FakeIdeaRepository();

        var idea = new Idea
        {
            Id = 1,
            Title = "Test Idea",
            Description = "This is a test idea.",
            VotesCount = 0,
            Status = IdeaStatus.InProgress
        };

        await fakeRepoIdea.AddAsync(idea);
        var allIdeas = await fakeRepoIdea.GetByIdAsync(1);

        Assert.IsNotNull(allIdeas);
        Assert.Equals("New idea", allIdeas.Title);

    }
}
