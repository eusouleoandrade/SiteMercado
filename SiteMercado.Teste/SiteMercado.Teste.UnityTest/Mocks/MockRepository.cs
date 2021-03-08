using SiteMercado.Teste.Domain.Entities;
using System.Collections.Generic;

namespace SiteMercado.Teste.UnityTest.Mocks
{
    public abstract class MockRepository
    {
        protected readonly IEnumerable<Produto> _produtoData;

        public MockRepository()
        {
            _produtoData = GetProdutoData();
        }

        private IEnumerable<Produto> GetProdutoData()
        {
            return new List<Produto>
            {
                new Produto("ProdutoA", 20.50M, 0),
                new Produto("ProdutoB", 134.50M, 0),
                new Produto("ProdutoC", 100M, 0)
            };
        }
    }
}
