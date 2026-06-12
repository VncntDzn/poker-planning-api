
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

    public async Task<Guid> Create(CreateTeamRequestDto createTeamRequestDto, CancellationToken cancellationToken)
    {
        var team = new Team()
        {
            Id = Guid.NewGuid(),
            Name = createTeamRequestDto.Name,
            TeamType = createTeamRequestDto.TeamType,
            TeamLeadUserId = createTeamRequestDto.TeamLeadUserId,
            CreatedByUserId = createTeamRequestDto.CreatedByUserId
        };

        _dbContext.Teams.Add(team);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return team.Id;
    }
}
