using System.ComponentModel.DataAnnotations;
using poker_planning_api.Domain.Enums;

namespace poker_planning_api.Features.Teams.CreateTeam;


public sealed record CreateTeamRequestDto
{
    [Required] public required string Name { get; init; }
    [Required] public Guid TeamLeadUserId { get; init; }
    [Required] public TeamType TeamType { get; set; }

    [Required] public Guid CreatedByUserId { get; set; }
}
