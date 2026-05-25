using Microsoft.AspNetCore.Mvc;
using poker_planning_api.Features.Rooms.CreateRoom;

namespace poker_planning_api.Features.Rooms;

[ApiController]
[Route("api/rooms")]
public class RoomsController: ControllerBase
{
    public readonly ICreateRoomHandler _createRoomHandler;

    public RoomsController(ICreateRoomHandler createRoom)
    {
        _createRoomHandler = createRoom;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateRoom([FromBody] CreateRoomRequestDto requestDto, CancellationToken ct)
    {
        var response = await _createRoomHandler.Create(requestDto, ct);
        
        return Ok(response);
    }
}