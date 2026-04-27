using poker_planning_api.Domain.Entities;
using poker_planning_api.Infrastructure.Persistence;
using poker_planning_api.Shared.Password;

namespace poker_planning_api.Features.Authentication.Signup;

public sealed class SignupHandler : ISignupHandler
{
    private readonly AppDbContext _dbContext;
    private readonly PasswordHandler _passwordHandler;

    public SignupHandler(AppDbContext dbContext, PasswordHandler passwordHandler)
    {
        _dbContext = dbContext;
        _passwordHandler = passwordHandler;
    }

    public async Task<Guid> Create(SignupRequestDto requestDto, CancellationToken ct)
    {
        var hashedPassword = _passwordHandler.HashPassword(requestDto.Password);

        var user = new User()
        {
            Email = requestDto.Email,
            Password = hashedPassword,
            FirstName = requestDto.FirstName,
            LastName = requestDto.LastName,
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(ct);

        return user.Id;
    }
}