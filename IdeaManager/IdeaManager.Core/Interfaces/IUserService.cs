using IdeaManager.Core.Entities;

namespace IdeaManager.Core.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<bool> UserExistsAsync(int id);
        Task<bool> UserExistsByEmailAsync(string email);
    }
}
