namespace poker_planning_api.Domain.Entities;

public sealed class RoomParticipant:BaseEntity
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }

    public required User User { get; set; }
}