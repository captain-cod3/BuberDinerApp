using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Buber.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace Buber.Infrastructure.Authentication;

public class JwtAuthenticationToken : IJwtAuthenticationToken
{
    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-longing-key")),
            SecurityAlgorithms.HmacSha256);

        var claims = new []{
          new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
          new Claim(JwtRegisteredClaimNames.GivenName, firstName),
          new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: "BuberDiner",
            expires: DateTime.Now.AddDays(1),
            claims : claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}