using poker_planning_api.Domain.Enums;

namespace poker_planning_api.Domain.Entities;

public sealed class Team : BaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public Guid TeamLeadUserId { get; set; }

    public User? TeamLead { get; set; }

    public TeamType TeamType { get; set; }

    public Guid CreatedByUserId { get; set; }

    public User? CreatedBy { get; set; }

}
