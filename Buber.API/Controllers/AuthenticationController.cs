using Buber.Application.Services.Authentication;
using Buber.Contract.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Buber.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase{

    private readonly IAuthenticationService _auth;

    public AuthenticationController(IAuthenticationService service)
    {
        _auth = service;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = _auth.Register(request.FirstName, request.LastName, request.Email, request.Password);

        var response = new AuthenticationResponse(
            result.user.Id,
            result.user.FirstName,
            result.user.LastName,
            result.user.Email,
            result.Token
        );

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = _auth.Login(request.Email, request.Password);

        var response = new AuthenticationResponse(
            result.user.Id,
            result.user.FirstName,
            result.user.LastName,
            result.user.Email,
            result.Token
        );

        return Ok(response);
    }
}