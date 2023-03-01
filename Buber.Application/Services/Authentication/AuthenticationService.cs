using Buber.Application.Common.Interfaces.Authentication;

namespace Buber.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtAuthenticationToken _token;

    public AuthenticationService(IJwtAuthenticationToken token)
    {
        _token = token;
    }
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(),"firstName", "lastName",email,password);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //check user exists

        //create a new user Id 

        //create a token
        var token = _token.GenerateToken(Guid.NewGuid(),firstName,lastName);
        return new AuthenticationResult(Guid.NewGuid(),firstName, lastName,email,token);
    }
}