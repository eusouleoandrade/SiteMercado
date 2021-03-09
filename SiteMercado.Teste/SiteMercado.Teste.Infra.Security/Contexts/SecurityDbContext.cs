using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SiteMercado.Teste.Infra.Security.Contexts
{
    public class SecurityDbContext : IdentityDbContext
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Altera os nomes de tabelas no banco de dados
            modelBuilder.Entity<IdentityRole>().ToTable("Security_Roles");
            modelBuilder.Entity<IdentityUser>().ToTable("Security_Users");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("Security_RoleClaims");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("Security_UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("Security_UserLogin");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("Security_UserRoles");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("Security_UserTokens");

            // Remove a deleção por cascata no banco de dados
            var cascadeFKs = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
