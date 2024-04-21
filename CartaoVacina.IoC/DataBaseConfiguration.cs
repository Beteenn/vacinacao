using CartaoVacina.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CartaoVacina.IoC;

public static class DataBaseConfiguration
{
    public static void ConfigureDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CartaoVacina");
        services.AddDbContext<CartaoVacinaContext>(opts => opts.UseSqlServer(connectionString));
    }
}
