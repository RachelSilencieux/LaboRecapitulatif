using System.Collections.Generic;
using System.Threading.Tasks;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;

namespace IdeaManager.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _unitOfWork.UserRepository.GetByIdAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            await _unitOfWork.UserRepository.AddAsync(user);
        }


        public async Task UpdateUserAsync(User user)
        {
            await _unitOfWork.UserRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _unitOfWork.UserRepository.DeleteAsync(id); 
        }

        public async Task<bool> UserExistsAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            return user != null;
        }

   
    }
}
