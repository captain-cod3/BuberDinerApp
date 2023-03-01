namespace Buber.Application.Common.Interfaces.Authentication;

public interface IJwtAuthenticationToken
{
    string GenerateToken(Guid userId, string firstName, string lastName);
}