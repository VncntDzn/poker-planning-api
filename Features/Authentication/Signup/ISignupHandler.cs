namespace poker_planning_api.Features.Authentication.Signup;

public interface ISignupHandler
{
    Task<Guid> Create(SignupRequestDto requestDto, CancellationToken ct);
}