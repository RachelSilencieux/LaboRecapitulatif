

namespace IdeaManager.Core.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public int IdeaId { get; set; }
        public Idea Idea { get; set; }
    }
}
