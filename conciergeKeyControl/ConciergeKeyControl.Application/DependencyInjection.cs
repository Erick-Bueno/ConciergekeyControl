using Microsoft.Extensions.DependencyInjection;

namespace DefaultNamespace;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuhtService, AuthService>();
        return services;
    }
}