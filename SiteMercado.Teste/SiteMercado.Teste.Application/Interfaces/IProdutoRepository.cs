using SiteMercado.Teste.Domain.Entities;

namespace SiteMercado.Teste.Application.Interfaces
{
    public interface IProdutoRepository : IGenericRepository<Produto>
    {
        Produto GetByNome(string nome);
    }
}
