namespace poker_planning_api.Shared.Password;

public sealed class PasswordHandler: IPasswordHandler
{
    public PasswordHandler()
    {
        
    }

    public string HashPassword(string password)
    {
        if(string.IsNullOrEmpty(password)) return "Password is empty";

        return password;
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        throw new NotImplementedException();
    }
}