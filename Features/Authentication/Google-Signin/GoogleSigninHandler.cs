using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Google.Apis.Auth;
using Microsoft.IdentityModel.Tokens;

namespace poker_planning_api.Features.Authentication.Google_Signin;

public sealed class GoogleSigninHandler: IGoogleSignin
{
    private readonly IConfiguration _config;

    public GoogleSigninHandler(IConfiguration config)
    {
        _config = config;
    }


    public string ValidateGoogleSignin(GoogleJsonWebSignature.Payload payload)
    {
        // 🔒 Validate audience (critical)
        if (payload.Audience != _config["Authentication:Google:ClientId"]){
            throw new Exception("Google Signin requires client ID");
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