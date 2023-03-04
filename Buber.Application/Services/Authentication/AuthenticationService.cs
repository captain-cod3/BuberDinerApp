using Buber.Application.Common.Interfaces.Authentication;
using Buber.Application.Common.Interfaces.Persistence;
using Buber.Domain.Entities;

namespace Buber.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtAuthenticationToken _token;
    private readonly IUserRepository _userRepo;

    public AuthenticationService(IJwtAuthenticationToken token, IUserRepository userRepo)
    {
        _userRepo = userRepo;
        _token = token;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //check user exists
        if(_userRepo.GetuserByEmail(email) is not null){
            throw new Exception("User exist with given email");
        }
        //create a new user Id 
        var user = new User{FirstName = firstName, LastName = lastName, Email = email, Password = password};
        _userRepo.AddUser(user); 

        //create a token
        var token = _token.GenerateToken(user);
        return new AuthenticationResult(user,token);
    }

    public AuthenticationResult Login(string email, string password)
    {  

        if(_userRepo.GetuserByEmail(email) is not User user)
            throw new Exception("User does not exist");

        if(user.Password != password)
            throw new Exception("Invalid password");

        var token = _token.GenerateToken(user);

        return new AuthenticationResult(user,token);
    }
}