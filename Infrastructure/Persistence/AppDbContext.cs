using Microsoft.EntityFrameworkCore;

namespace poker_planning_api.Infrastructure;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Example table
   // public DbSet<PokerSession> PokerSessions => Set<PokerSession>();
}