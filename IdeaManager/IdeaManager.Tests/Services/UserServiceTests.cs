using IdeaManager.Core.Entities;
using IdeaManager.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace IdeaManager.Tests;

public class UserServiceTests
{
    [Fact]
    public async Task AddUser_Test()
    {
        var fakeRepoUser = new FakeUserRepository();

        var user = new User
        {
            Id = 1,
            Username = "testuser",
            Email = "test@test.com",
            PasswordHash = "hashedpassword",
            Votes = new List<Vote>()
        };

        await fakeRepoUser.AddAsync(user);
        var addedUser = await fakeRepoUser.GetByIdAsync(1);

        Assert.IsNotNull(addedUser);
        Assert.AreEqual(user.Username, addedUser.Username);
    }
}
