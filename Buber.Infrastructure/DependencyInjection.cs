using Buber.Application.Common.Interfaces.Authentication;
using Buber.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Buber.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtAuthenticationToken,JwtAuthenticationToken>();
        return services;
    }
}