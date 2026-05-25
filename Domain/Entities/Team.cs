namespace poker_planning_api.Domain.Entities;

public sealed class Team: BaseEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public Guid CreatedByUserId { get; set; }
    
    public required User CreatedBy { get; set; }
}