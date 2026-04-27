using System.ComponentModel.DataAnnotations;

namespace poker_planning_api.Features.Authentication.Signup;

public sealed class SignupRequestDto
{
    [Required]
    public required string FirstName { get; init; }
    [Required]
    public required string LastName { get; init; }
    [Required]
    public required string Email { get; init; }
    [Required]
    public required string Password { get; init; }
}