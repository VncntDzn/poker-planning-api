using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Google.Apis.Auth;
using Microsoft.IdentityModel.Tokens;

namespace poker_planning_api.Features.Authentication.Google_Signin;

public sealed class GoogleSigninHandler: IGoogleSigninHandler
{
    private readonly IConfiguration _config;

    public GoogleSigninHandler(IConfiguration config)
    {
        _config = config;
    }


    public string ValidateGoogleSignin(GoogleJsonWebSignature.Payload payload)
    {
        // 🔒 Validate audience (critical)
        var googleClientId = _config["Authentication:Google:ClientId"];

        if (string.IsNullOrWhiteSpace(googleClientId))
        {
            throw new Exception("Google client ID is not configured");
        }

        var audience = payload.Audience?.ToString();

        if (!string.Equals(audience, googleClientId, StringComparison.Ordinal))
        {
            throw new Exception("Invalid Google client ID");
        }

        // Extract identity
        var email = payload.Email;
        var googleId = payload.Subject;
        var token = GenerateJwt(email);
        
        return token;
    }
    
    private string GenerateJwt(string email)

    {

        var key = new SymmetricSecurityKey(

            Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]

        {

            new Claim(ClaimTypes.Email, email),

        };

        var token = new JwtSecurityToken(

            issuer: _config["Jwt:Issuer"],

            audience: _config["Jwt:Audience"],

            claims: claims,

            expires: DateTime.UtcNow.AddHours(1),

            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}