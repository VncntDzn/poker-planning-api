using Google.Apis.Auth;

namespace poker_planning_api.Features.Authentication.Google_Signin;

public interface IGoogleSigninHandler
{
    string ValidateGoogleSignin(GoogleJsonWebSignature.Payload payload);
}