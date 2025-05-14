
using Microsoft.EntityFrameworkCore;
using IdeaManager.Core.Entities;
using IdeaManager.Data.Configurations;

namespace IdeaManager.Data.Db
{
    public class IdeaDbContext : DbContext
    {
        public IdeaDbContext(DbContextOptions<IdeaDbContext> options) : base(options) {}
        public DbSet<Idea> Ideas => Set<Idea>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Vote> Votes => Set<Vote>();
        public DbSet<Project> Projects => Set<Project>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IdeaConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new VoteConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        }
    }   
  
}
