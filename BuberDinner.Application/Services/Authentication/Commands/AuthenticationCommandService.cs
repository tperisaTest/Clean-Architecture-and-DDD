using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Commands
{
    public class AuthenticationCommandService : IAuthenticationCommandService
    {
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationCommandService(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            if (_userRepository.GetByEmail(email) != null)
            {
                return Errors.User.DuplicateEmail;
            }
            var user = new User
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Password = password
            };
            _userRepository.Add(user);
            var token = _tokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
