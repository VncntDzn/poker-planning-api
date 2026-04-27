using System.ComponentModel.DataAnnotations;

namespace poker_planning_api.Features.Rooms.CreateRoom;

public  sealed record CreateRoomRequestDto
{
    [Required]
    public required string Name { get; init; }
}