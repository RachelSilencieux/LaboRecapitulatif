using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using IdeaManager.Core.Enums;

namespace IdeaManager.Services.Services
{
    public class IdeaService : IIdeaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IdeaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IdeaService() { }
        public async Task SubmitIdeaAsync(Idea idea)
        {
            if (string.IsNullOrWhiteSpace(idea.Title))
                throw new ArgumentException("Le titre est obligatoire.");

            idea.VotesCount = 0;
            idea.Status = IdeaStatus.InProgress;

            await _unitOfWork.IdeaRepository.AddAsync(idea);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<List<Idea>> GetAllIdeasAsync()
        {
            return await _unitOfWork.IdeaRepository.GetAllAsync();
        }

        public async Task VoteForIdeaAsync(int ideaId)
        {
            var idea = await _unitOfWork.IdeaRepository.GetByIdAsync(ideaId);

            if (idea == null)
                throw new InvalidOperationException("Idée non trouvée.");

            idea.VotesCount++;
            await _unitOfWork.IdeaRepository.AddAsync(idea);
        }

    }
}
