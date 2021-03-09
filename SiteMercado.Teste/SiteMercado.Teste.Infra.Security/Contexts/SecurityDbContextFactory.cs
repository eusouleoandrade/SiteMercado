using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SiteMercado.Teste.Infra.Security.Contexts
{
    public class SecurityDbContextFactory : IDesignTimeDbContextFactory<SecurityDbContext>
    {
        public SecurityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SecurityDbContext>();

            optionsBuilder.UseSqlServer("Server=DESKTOP-EEROSVH;Database=SiteMercadoDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new SecurityDbContext(optionsBuilder.Options);
        }
    }
}
