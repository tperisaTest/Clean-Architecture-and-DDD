using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using Riok.Mapperly.Abstractions;

namespace BuberDinner.API.Common.Mapping
{
    [Mapper]
    public partial class AuthenticationMapper
    {
        public partial LoginQuery LoginRequestToLoginQuery(LoginRequest request);

        [MapProperty(new[] { nameof(AuthenticationResult.User), nameof(AuthenticationResult.User.Id) }, new[] { nameof(AuthenticationResponse.Id) })]
        [MapProperty("User.FirstName", "FirstName")]
        [MapProperty("User.LastName", "LastName")]
        [MapProperty("User.Email", "Email")]
        public partial AuthenticationResponse AuthenticationResultToAuthenticationResponse(AuthenticationResult result);
        public partial RegisterCommand RegisterRequestToRegisterCommand(RegisterRequest request);
    }
}
