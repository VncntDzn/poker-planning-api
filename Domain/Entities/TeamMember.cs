namespace poker_planning_api.Domain.Entities;

public sealed class TeamMember:BaseEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required User User { get; set; }
    public Guid TeamId { get; set; }
    public required Team Team { get; set; }
} 