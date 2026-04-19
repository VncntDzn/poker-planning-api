namespace poker_planning_api.Domain.Entities;

public sealed class User:BaseEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; } =  string.Empty;
    public string FirstName { get; set; } =  string.Empty;
    public string LastName { get; set; } =  string.Empty;
    public string Password { get; set; } =  string.Empty;
}