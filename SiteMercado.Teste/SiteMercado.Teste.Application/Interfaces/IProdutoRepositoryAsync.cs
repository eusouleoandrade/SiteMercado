using SiteMercado.Teste.Domain.Entities;
using System.Threading.Tasks;

namespace SiteMercado.Teste.Application.Interfaces
{
    public interface IProdutoRepositoryAsync : IGenericRepositoryAsync<Produto>
    {
        Task<Produto> GetProdutoByNome(string nome);
    }
}
