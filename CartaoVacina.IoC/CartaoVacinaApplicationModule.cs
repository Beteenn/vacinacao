using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CartaoVacina.IoC;

public static class CartaoVacinaApplicationModule
{
    public static IServiceCollection ConfigureDependencies(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
    {
        services.ConfigureDataBase(configuration, isDevelopment);
        services.ConfigureRepositories();
        services.ConfigureServices();
        services.ConfigureSwagger();

        return services;
    }
}
