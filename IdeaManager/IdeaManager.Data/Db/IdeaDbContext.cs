
using Microsoft.EntityFrameworkCore;
using IdeaManager.Core.Entities;
using IdeaManager.Data.Configurations;

namespace IdeaManager.Data.Db
{
    public class IdeaDbContext : DbContext
    {
        public IdeaDbContext() : base()
        {

        }
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

            modelBuilder.Entity<Idea>().HasData(
                new Idea
                {
                    Id = 1,
                    Title = "Idea 1",
                    Description = "Description for Idea 1",
                    ProjectId = 1
                },
                new Idea
                {
                    Id = 2,
                    Title = "Idea 2",
                    Description = "Description for Idea 2",
                    ProjectId = 2
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ideaManager.db");
        }
       

        }

    }
