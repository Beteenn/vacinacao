using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CartaoVacina.IoC;

public static class CartaoVacinaApplicationModule
{
    public static IServiceCollection ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureDataBase(configuration);
        services.ConfigureRepositories();
        services.ConfigureServices();
        services.ConfigureSwagger();

        return services;
    }
}
