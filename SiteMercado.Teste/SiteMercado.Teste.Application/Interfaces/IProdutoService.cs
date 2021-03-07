using SiteMercado.Teste.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SiteMercado.Teste.Application.Interfaces
{
    public interface IProdutoService
    {
        IReadOnlyList<Produto> GetAllProdutos();

        Produto GetProdutoById(Guid id);

        void CreateProduto(Produto entity);

        void DeleteProduto(Guid id);

        void UpdateProduto(Produto entity);
    }
}
