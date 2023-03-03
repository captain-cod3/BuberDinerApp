using Buber.Application.Common.Interfaces.Authentication;
using Buber.Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Buber.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));  //implements options pattern.
        services.AddSingleton<IJwtAuthenticationToken,JwtAuthenticationToken>();
        return services;
    }
}