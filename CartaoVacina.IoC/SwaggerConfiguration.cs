using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CartaoVacina.IoC;

public static class SwaggerConfiguration
{
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.EnableAnnotations();

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Cartao Vacina - Api",
                Description = "API para gerenciamento de Cartoes de Vacina.",
                Version = "v1"
            });
        });
    }
}
