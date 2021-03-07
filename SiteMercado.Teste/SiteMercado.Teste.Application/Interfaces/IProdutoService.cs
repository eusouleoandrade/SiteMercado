using SiteMercado.Teste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteMercado.Teste.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<IReadOnlyList<Produto>> GetAllProdutos();

        Task<Produto> GetProdutoById(Guid id);

        void CreateProduto(Produto entity);

        void DeleteProduto(Produto entity);

        void UpdateProduto(Produto entity);
    }
}
