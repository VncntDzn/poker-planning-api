using poker_planning_api.Domain.Entities;
using poker_planning_api.Features.Rooms.CreateRoom;

namespace poker_planning_api.Features.Rooms.CreateRoom;

public interface ICreateRoomHandler
{
    Task<Guid> Create(CreateRoomRequestDto requestDto, CancellationToken ct);
}