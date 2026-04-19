using Microsoft.EntityFrameworkCore;
using poker_planning_api.Domain.Entities;

namespace poker_planning_api.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<RoomParticipant> RoomParticipants => Set<RoomParticipant>();
    public DbSet<Round> Rounds => Set<Round>();
    public DbSet<Story> Stories => Set<Story>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Vote> Votes => Set<Vote>();
    
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
   }