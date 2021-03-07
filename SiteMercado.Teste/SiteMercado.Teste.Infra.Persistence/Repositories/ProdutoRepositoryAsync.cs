using SiteMercado.Teste.Application.Exceptions;
using SiteMercado.Teste.Application.Interfaces;
using SiteMercado.Teste.Domain.Entities;
using SiteMercado.Teste.Infra.Persistence.Contexts;
using System.Threading.Tasks;

namespace SiteMercado.Teste.Infra.Persistence.Repositories
{
    public class ProdutoRepositoryAsync : GenericRepositoryAsync<Produto>, IProdutoRepositoryAsync
    {
        public ProdutoRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Produto> GetProdutoByNome(string nome)
        {
            try
            {
                return await _dbContext.Produtos.FindAsync(nome);
            }
            catch (System.Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }
    }
}
