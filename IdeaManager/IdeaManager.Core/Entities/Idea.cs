 
using IdeaManager.Core.Enums;

namespace IdeaManager.Core.Entities
{
    public class Idea
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public IdeaStatus Status { get; set; } = IdeaStatus.Pending;
        public int VotesCount { get; set; } = 0;

        public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();

        public int? ProjectId { get; set; }
        public Project? Project { get; set; }

    }
}
