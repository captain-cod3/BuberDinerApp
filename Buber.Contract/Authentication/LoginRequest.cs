namespace Buber.Contract.Authentication;

public record LoginRequest(
    string Email,
    string Password
);