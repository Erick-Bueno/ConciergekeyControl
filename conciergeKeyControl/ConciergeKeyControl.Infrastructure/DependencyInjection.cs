using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
public static class DependencyInjection{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration){
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
        services.AddScoped<IAuhtService, AuthService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAes256, Aes256>();
        return services;
    }
}