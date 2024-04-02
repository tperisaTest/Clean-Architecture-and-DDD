using BuberDinner.API.Common.Mapping;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly AuthenticationMapper _authenticationMapper;
        public AuthenticationController(ISender mediator, AuthenticationMapper authenticationMapper)
        {
            _mediator = mediator;
            _authenticationMapper = authenticationMapper;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _authenticationMapper.LoginRequestToLoginQuery(request);
            ErrorOr<AuthenticationResult> result = await _mediator.Send(query);
            return result.Match(
                value => Ok(_authenticationMapper.AuthenticationResultToAuthenticationResponse(value)),
                errors => Problem(errors)
                );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _authenticationMapper.RegisterRequestToRegisterCommand(request);
            ErrorOr<AuthenticationResult> result = await _mediator.Send(command);
            return result.Match(
                value => Ok(_authenticationMapper.AuthenticationResultToAuthenticationResponse(value)),
                errors => Problem(errors)
                );
        }
    }
}
