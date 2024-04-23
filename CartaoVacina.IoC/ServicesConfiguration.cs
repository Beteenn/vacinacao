using CartaoVacina.Application.Services;
using CartaoVacina.Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CartaoVacina.IoC;

public static class ServicesConfiguration
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IPessoaService, PessoaService>();
        services.AddScoped<IVacinaService, VacinaService>();
    }
}
