using IdentityService.Domain.Services;
using IdentityService.Infrastucture.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace IdentityService.Infrastucture;

public static class DependencyInjaction
{
    public static IServiceCollection AddInfrastucture(
        this IServiceCollection services,
        IConfiguration configuration
    ) =>
        services
            .AddAuthenticationInternal();

    private static IServiceCollection AddAuthenticationInternal(this IServiceCollection services)
    {
        services.AddSingleton<IPasswordService, PasswordService>();
        
        return services;
    }
}