using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IdeaManager.Core.Entities;

namespace IdeaManager.Data.Configurations
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.HasKey(v => v.Id);

            builder.HasOne(v => v.Idea)
                .WithMany(i => i.Votes)
                .HasForeignKey(v => v.IdeaId);

            builder.HasOne(v => v.User)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.UserId);

            builder.Property(v => v.VotedAt)
                .IsRequired();
        }

    }
}
