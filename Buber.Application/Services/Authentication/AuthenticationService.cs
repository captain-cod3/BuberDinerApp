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
        var token = _token.GenerateToken(user.Id,user.FirstName,user.LastName);
        return new AuthenticationResult(user.Id,user.FirstName, user.LastName,user.Email,token);
    }

    public AuthenticationResult Login(string email, string password)
    {   
        var user = _userRepo.GetuserByEmail(email);
        if( user is not null)
        {
            if(user.Password == password){
                var token = _token.GenerateToken(user.Id,user.FirstName,user.LastName);
                return new AuthenticationResult(user.Id,user.FirstName,user.LastName,user.Email,token);
            }
        }

        return new AuthenticationResult(Guid.NewGuid(),"firstName", "lastName",email,password);
    }
}