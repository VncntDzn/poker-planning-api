using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poker_planning_api.Domain.Entities;

namespace poker_planning_api.Infrastructure.Persistence.Configurations;

public sealed class RoomParticipantConfiguration: IEntityTypeConfiguration<RoomParticipant>
{
    public void Configure(EntityTypeBuilder<RoomParticipant> builder)
    {
        builder.ToTable("RoomParticipants");

        builder.HasKey(rm => rm.Id);
        
        
        // relationships
        builder.HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(r => r.UserId);
    }    
}