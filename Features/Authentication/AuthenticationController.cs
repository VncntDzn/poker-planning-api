using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using poker_planning_api.Features.Authentication.Google_Signin;
using poker_planning_api.Features.Authentication.Signup;

namespace poker_planning_api.Features.Authentication;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly ISignupHandler _signupHandler;
    private readonly IGoogleSignin _googleSignin;

    public AuthenticationController(ISignupHandler signupHandler, IGoogleSignin googleSignin)
    {
        _signupHandler = signupHandler;
        _googleSignin = googleSignin;
    }

    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup([FromBody] SignupRequestDto requestDto, CancellationToken ct)
    {
        var response = await _signupHandler.Create(requestDto, ct);
        return Ok(response);
    }

    [HttpPost("signin")]
    public async Task<IActionResult> Signin()
    {
        throw new NotImplementedException();
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }


    [HttpPost("google-signin")]
    public async Task<IActionResult> GoogleSignin([FromBody] GoogleSigninRequestDto request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.IdToken))

            return BadRequest("Missing ID token");
       
        GoogleJsonWebSignature.Payload payload;
        try
        {
            payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken);
        }
        catch (Exception e)
        {
            return Unauthorized("Invalid Google token");
        }


        var token = _googleSignin.ValidateGoogleSignin(payload);

        return Ok(new

        {
            accessToken = token
        });
    }
}