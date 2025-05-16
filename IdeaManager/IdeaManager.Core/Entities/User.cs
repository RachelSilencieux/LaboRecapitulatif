

namespace IdeaManager.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string PasswordHash { get; set; } = String.Empty;
        public ICollection<Vote> Votes { get; set; } = new List<Vote>();

    }
}
