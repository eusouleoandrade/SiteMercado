using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SiteMercado.Teste.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SiteMercado",
                    Version = "v1",
                    Description = "API de Teste"
                });
            });
        }
    }
}
