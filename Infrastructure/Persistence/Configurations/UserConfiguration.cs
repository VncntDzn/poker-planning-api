using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poker_planning_api.Domain.Entities;

namespace poker_planning_api.Infrastructure.Persistence.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Email)
            .IsUnique();
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
    }
}