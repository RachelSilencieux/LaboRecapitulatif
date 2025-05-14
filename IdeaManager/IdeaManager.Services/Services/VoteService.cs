using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;

namespace IdeaManager.Services.Services
{
    public class VoteService : IVoteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public VoteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Vote>> GetAllVotesAsync()
        {
            return await _unitOfWork.VoteRepository.GetAllAsync();
        }


        public async Task<Vote?> GetVoteByIdAsync(int id)
        {
            return await _unitOfWork.VoteRepository.GetByIdAsync(id);
        }
        public async Task AddVoteAsync(Vote vote)
        {
            await _unitOfWork.VoteRepository.AddAsync(vote);
        }
        public async Task UpdateVoteAsync(Vote vote)
        {
            await _unitOfWork.VoteRepository.UpdateAsync(vote);
        }
        public async Task DeleteVoteAsync(int id)
        {
            await _unitOfWork.VoteRepository.DeleteAsync(id);
        }


    }
}
