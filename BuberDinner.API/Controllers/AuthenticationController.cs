using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var result = _authenticationService.Login(request.Email, request.Password);
            var response = new AuthenticationResponse(result.Id, result.FirstName, result.LastName, result.Email, result.Password);
            return Ok(response);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var result = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
            var response = new AuthenticationResponse(result.Id, result.FirstName, result.LastName, result.Email, result.Password);
            return Ok(response);
        }
    }
}
