using System.ComponentModel.DataAnnotations;

namespace poker_planning_api.Features.Rooms.CreateRoom;

public sealed record CreateRoomRequestDto
{
    [Required] public required string Name { get; init; }
    [Required] public required string Team { get; init; }
    [Required] public required string NumOfParticipants { get; init; }
    [Required] public required string DeckType { get; init; }
    [Required] public required bool RoomVisibility { get; init; }
    [Required] public required string VoteMode { get; init; }
}