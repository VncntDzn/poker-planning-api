using poker_planning_api.Domain.Enums;

namespace poker_planning_api.Domain.Entities;

public class Story:BaseEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; }

    
    public StoryType Type { get; set; }
    public Guid RoomId { get; set; }

    public required Room Room { get; set; }
}