using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poker_planning_api.Domain.Entities;

namespace poker_planning_api.Infrastructure.Persistence.Configurations;

public sealed class RoundConfiguration : IEntityTypeConfiguration<Round>
{
    public void Configure(EntityTypeBuilder<Round> builder)
    {
        builder.ToTable("Rounds");

        // relationships
        builder.HasOne(r => r.Story)
            .WithMany()
            .HasForeignKey(r => r.StoryId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(r => r.StoryId);
    }
}