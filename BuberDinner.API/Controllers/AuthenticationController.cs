using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Services.Authentication.Commands;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationQueryService _authenticationQueryService;
        private readonly IAuthenticationCommandService _authenticationCommandService;
        public AuthenticationController(IAuthenticationQueryService authenticationQueryService, IAuthenticationCommandService authenticationCommandService)
        {
            _authenticationQueryService = authenticationQueryService;
            _authenticationCommandService = authenticationCommandService;
        }
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            ErrorOr<AuthenticationResult> result = _authenticationQueryService.Login(request.Email, request.Password);
            return result.Match(
                value => Ok(MapAuthResult(value)),
                errors => Problem(errors)
                );
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> result = _authenticationCommandService.Register(request.FirstName, request.LastName, request.Email, request.Password);
            return result.Match(
                value => Ok(MapAuthResult(value)),
                errors => Problem(errors)
                );
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);
        }
    }
}
