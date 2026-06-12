

using Microsoft.AspNetCore.Mvc;
using poker_planning_api.Features.Teams.CreateTeam;

namespace poker_planning_api.Features.Teams;


[ApiController]
[Route("api/teams")]
public class TeamsController : ControllerBase
{
    public readonly ICreateTeamHandler _createTeamHandler;
    public TeamsController(ICreateTeamHandler createTeamHandler)
    {
        _createTeamHandler = createTeamHandler;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateTeam([FromBody] CreateTeamRequestDto requestDto, CancellationToken ct)
    {
        var response = await _createTeamHandler.Create(requestDto, ct);

        return Created($"/api/teams/{response}", response);
    }
}
