using SiteMercado.Teste.Application.Exceptions;
using SiteMercado.Teste.Application.Interfaces;
using SiteMercado.Teste.Domain.Entities;
using SiteMercado.Teste.Infra.Persistence.Contexts;
using System.Linq;

namespace SiteMercado.Teste.Infra.Persistence.Repositories
{
    public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Produto GetByNome(string nome)
        {
            try
            {
                return _dbContext.Produtos.Where(w => w.Nome == nome).FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public override void Update(Produto entity)
        {
            try
            {
                DetachLocal(d => d.Id == entity.Id);
                _dbContext.Produtos.Update(entity);
                _dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {

                throw new RepositoryException(ex);
            }
        }
    }
}
