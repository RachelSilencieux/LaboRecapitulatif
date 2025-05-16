

namespace IdeaManager.Core.Entities
{
    public class Vote
    {
        public int Id { get; set; }
        public int IdeaId { get; set; }
        public Idea Idea { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime VotedAt { get; set; } = DateTime.UtcNow;
    }
}
