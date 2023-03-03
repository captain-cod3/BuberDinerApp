namespace Buber.Infrastructure.Authentication;

public class JwtSettings{
    public const string SectionName = "JwtSettings"; // as value inside GetSections was mocking the exact same structure as in appsetting.json
    public string Secret { get; init; } = null!;
    public int ExpirationTimeinMinutes { get; init; }
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
}