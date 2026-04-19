using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poker_planning_api.Domain.Entities;

namespace poker_planning_api.Infrastructure.Persistence.Configurations;

public sealed class StoryConfiguration:IEntityTypeConfiguration<Story>
{
    public void Configure(EntityTypeBuilder<Story> builder)
    {
        builder.ToTable("Stories");
        
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(150);
        builder.Property(s => s.Description);
        
        builder.Property(s => s.Type).IsRequired();
        
        // relationships
        builder.HasOne(r => r.Room)
            .WithMany()
            .HasForeignKey(r => r.RoomId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(r => r.RoomId);
    }
}