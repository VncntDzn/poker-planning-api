using poker_planning_api.Domain.Entities;
using poker_planning_api.Features.Rooms.CreateRoom;
using poker_planning_api.Infrastructure.Persistence;

namespace poker_planning_api.Features.Rooms.CreateRoom;

public sealed class CreateRoomHandler: ICreateRoomHandler
{
    private readonly AppDbContext _dbContext;
    
    public CreateRoomHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Create(CreateRoomRequestDto createRoomRequestDto, CancellationToken ct)
    {
        
        if (string.IsNullOrWhiteSpace(createRoomRequestDto.Name))
        {
            throw new ArgumentException("Room name is required.", nameof(createRoomRequestDto));

        }
        var generatedSlug = GenerateSlug(createRoomRequestDto.Name);

        var room = new Room()
        {
            Name = createRoomRequestDto.Name,
            Slug = generatedSlug,
            User = null
        };

        return room.Id;
    }

    

    private static string GenerateSlug(string name)
    {
        var normalized = name
            .ToLowerInvariant()
            .Trim();

        var slug = new string(normalized
            .Select(c => char.IsLetterOrDigit(c) ? c : '-')
            .ToArray());

        slug = string.Join("-", slug
            .Split('-', StringSplitOptions.RemoveEmptyEntries));

        return slug;
    }
}