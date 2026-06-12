using poker_planning_api.Features.Teams.CreateTeam;

namespace poker_planning_api.Features.Teams;

public interface ICreateTeamHandler
{
    Task<Guid> Create(CreateTeamRequestDto createTeamRequestDto, CancellationToken cancellationToken);
}