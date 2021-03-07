using Microsoft.EntityFrameworkCore;
using SiteMercado.Teste.Domain.Entities;
using System.Linq;

namespace SiteMercado.Teste.Infra.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var cascadeFKs = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
