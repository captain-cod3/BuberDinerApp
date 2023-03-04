using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Buber.Application.Common.Interfaces.Authentication;
using Buber.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Buber.Infrastructure.Authentication;

public class JwtAuthenticationToken : IJwtAuthenticationToken
{
    private readonly JwtSettings _settings;

    public JwtAuthenticationToken(IOptions<JwtSettings> settings)
    {
        _settings = settings.Value;
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret)),    ///Using Options pattern to fill out the values
            SecurityAlgorithms.HmacSha256);

        var claims = new []{
          new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
          new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
          new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
          new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            expires: DateTime.UtcNow.AddMinutes(_settings.ExpirationTimeinMinutes),
            claims : claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}