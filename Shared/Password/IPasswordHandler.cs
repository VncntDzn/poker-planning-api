namespace poker_planning_api.Shared.Password;

public interface IPasswordHandler
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}