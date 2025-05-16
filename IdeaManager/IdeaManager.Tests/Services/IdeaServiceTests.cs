using IdeaManager.Core.Entities;
using IdeaManager.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace IdeaManager.Tests;

[TestClass]
public class IdeaServiceTests
{
    [TestMethod]
    public async Task AddIdea_Test()
    {
        var fakeRepoIdea = new FakeIdeaRepository();
        var idea = new Idea
        {
            Id = 1,
            Title = "Ceci est un test",
            Description = "description du test",
            VotesCount = 0,
            Status = IdeaStatus.InProgress
        };

        await fakeRepoIdea.AddAsync(idea);
        var result = await fakeRepoIdea.GetAllAsync();

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(idea.Title, result[0].Title);

    }
}
