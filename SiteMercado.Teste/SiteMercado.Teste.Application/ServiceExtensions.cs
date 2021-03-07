using Microsoft.Extensions.DependencyInjection;
using SiteMercado.Teste.Application.Interfaces;
using SiteMercado.Teste.Application.Services;

namespace SiteMercado.Teste.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
        }
    }
}
