using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiteMercado.Teste.Application.Interfaces;
using SiteMercado.Teste.Infra.Persistence.Contexts;
using SiteMercado.Teste.Infra.Persistence.Repositories;

namespace SiteMercado.Teste.Infra.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
               configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            #region Repositories
            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddScoped<IProdutoRepositoryAsync, ProdutoRepositoryAsync>();
            #endregion
        }
    }
}
