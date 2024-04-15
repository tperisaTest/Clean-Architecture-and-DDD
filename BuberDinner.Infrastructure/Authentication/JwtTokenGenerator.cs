using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Domain.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BuberDinner.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JwtTokenOptions _jwtTokenOptions;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtTokenOptions> jwtTokenOptions)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtTokenOptions = jwtTokenOptions.Value;
        }

        public string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenOptions.Secret));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,user.LastName)
            };

            var securityToken = new JwtSecurityToken(issuer: _jwtTokenOptions.Issuer, expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtTokenOptions.ExpiryMinutes), claims: claims, signingCredentials: signingCredentials, audience: _jwtTokenOptions.Audience);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
