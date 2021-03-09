using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiteMercado.Teste.Infra.Security.Contexts;
using SiteMercado.Teste.Infra.Security.Interfaces;
using SiteMercado.Teste.Infra.Security.Services;

namespace SiteMercado.Teste.Infra.Security
{
    public static class ServiceRegistration
    {
        public static void AddSecurityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAccountService, AccountService>();

            services.AddDbContext<SecurityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(SecurityDbContext).Assembly.FullName)));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SecurityDbContext>();
        }
    }
}
