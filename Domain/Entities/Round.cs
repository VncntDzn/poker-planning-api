namespace poker_planning_api.Domain.Entities;

public class Round: BaseEntity
{
    public Guid Id { get; set; }
    
    public Guid StoryId { get; set; }
    
    public required Story Story { get; set; }
}