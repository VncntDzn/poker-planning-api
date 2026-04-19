using poker_planning_api.Domain.Enums;

namespace poker_planning_api.Domain.Entities;



public sealed class Vote:BaseEntity
{
    public Guid Id { get; set; }
    
    public VoteType Type { get; set; }
    
    public Guid UserId { get; set; }

    public required User User { get; set; }
}