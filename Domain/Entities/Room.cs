using poker_planning_api.Domain.Enums;

namespace poker_planning_api.Domain.Entities;

public sealed class Room:BaseEntity
{
    public Guid Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string Slug { get; set; }
    
    public RoomStatus Status { get; set; }
  
        
    public Guid UserId { get; set; }

    public required User User { get; set; }

}