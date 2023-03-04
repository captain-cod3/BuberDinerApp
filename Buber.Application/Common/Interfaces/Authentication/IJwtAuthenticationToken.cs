using Buber.Domain.Entities;

namespace Buber.Application.Common.Interfaces.Authentication;

public interface IJwtAuthenticationToken
{
    string GenerateToken(User user);
}