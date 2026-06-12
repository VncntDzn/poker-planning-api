
using poker_planning_api.Domain.Entities;
using poker_planning_api.Infrastructure.Persistence;

namespace poker_planning_api.Features.Teams.CreateTeam;


public sealed class CreateTeamHandler : ICreateTeamHandler
{
    private readonly AppDbContext _dbContext;

    public CreateTeamHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Guid> Create(CreateTeamRequestDto createTeamRequestDto, CancellationToken cancellationToken)
    {
        var team = new Team()
        {
            Name = createTeamRequestDto.Name,
            TeamType = createTeamRequestDto.TeamType,
            TeamLeadUserId = createTeamRequestDto.TeamLeadUserId,
            CreatedByUserId = createTeamRequestDto.CreatedByUserId
        };

        return Task.FromResult(team.Id);
    }
}
