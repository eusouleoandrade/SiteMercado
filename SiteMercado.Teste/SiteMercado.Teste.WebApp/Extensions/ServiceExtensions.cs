using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using SiteMercado.Teste.WebApp.Configurations;
using System;
using System.Net.Http;

namespace SiteMercado.Teste.WebApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddHttpClientProdutoApi(this IServiceCollection services, IConfiguration configuration)
        {
            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(10);
            services.AddHttpClient("ApiProdutosClient", (c) =>
            {
                c.BaseAddress = new Uri(configuration.GetValue<String>("ApiProdutos:UrlBase"));
                c.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }).AddPolicyHandler(ResilienceConfig.GetRetryPolicy()).AddPolicyHandler(timeoutPolicy);
        }
    }
}
