using IdentityService.Domain.Services;
using IdentityService.Infrastucture.Presistence;
using IdentityService.Infrastucture.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace IdentityService.Infrastucture;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastucture(
        this IServiceCollection services,
        IConfiguration configuration
    ) =>
        services
            .AddDbContext(configuration)
            .AddAuthenticationInternal();

    private static IServiceCollection AddAuthenticationInternal(this IServiceCollection services)
    {
        services.AddSingleton<IPasswordService, PasswordService>();
        
        return services;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<IdentityDbContext>(opt =>
        {
            opt.UseNpgsql(connectionString, builder =>
            {
                builder.MigrationsAssembly(typeof(IdentityDbContext).Assembly.FullName);
            });
        });    
        
        return services;
    }
}