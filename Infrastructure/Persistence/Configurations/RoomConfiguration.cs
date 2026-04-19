using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poker_planning_api.Domain.Entities;

namespace poker_planning_api.Infrastructure.Persistence.Configurations;

public sealed class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms");

        builder.HasKey(r => r.Id);
        builder.HasIndex(r => r.Slug).IsUnique();
        builder.Property(r => r.Name).IsRequired().HasMaxLength(128);
        builder.Property(x => x.Status)
            .HasConversion<int>()
            .IsRequired();


        // relationships
        builder.HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(r => r.UserId);
    }
}