using CartaoVacina.Core.Interfaces.Repositories;
using CartaoVacina.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CartaoVacina.IoC;

public static class RepositoriesConfiguration
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPessoaRepository, PessoaRepository>();
        services.AddScoped<IVacinaRepository, VacinaRepository>();
    }
}
