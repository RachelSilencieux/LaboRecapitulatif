using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeaManager.Core.Entities;

namespace IdeaManager.Core.Interfaces
{
    public interface IVoteService
    {
    
        Task<Vote?> GetVoteByIdAsync(int id);

        Task AddVoteAsync(Vote vote);
    }
}
