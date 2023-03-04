using Buber.Domain.Entities;

namespace Buber.Application.Services.Authentication;

public record AuthenticationResult(
    User user,
    string  Token
);