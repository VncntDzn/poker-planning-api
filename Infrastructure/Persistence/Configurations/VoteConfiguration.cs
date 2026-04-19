using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poker_planning_api.Domain.Entities;

namespace poker_planning_api.Infrastructure.Persistence.Configurations;

public sealed class VoteConfiguration: IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder.ToTable("Votes");
        
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Type).IsRequired();
        
        
        // relationships
        builder.HasOne(v => v.User)
            .WithMany()
            .HasForeignKey(v => v.UserId) 
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasIndex(v => v.UserId);
    }
}