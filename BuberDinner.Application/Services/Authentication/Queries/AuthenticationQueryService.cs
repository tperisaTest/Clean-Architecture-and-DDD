using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationQueryService : IAuthenticationQueryService
    {
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationQueryService(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            if (_userRepository.GetByEmail(email) is not User user)
            {
                return Errors.User.VoidUser;
            }
            var token = _tokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
