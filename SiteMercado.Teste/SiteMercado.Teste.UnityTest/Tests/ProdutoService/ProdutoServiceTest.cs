using SiteMercado.Teste.Application.Interfaces;
using SiteMercado.Teste.Application.Services;
using SiteMercado.Teste.UnityTest.Mocks;

namespace SiteMercado.Teste.UnityTest.Tests
{
    public abstract class ProdutoServiceTest
    {
        protected readonly IProdutoService _produtoService;
        protected readonly IProdutoRepository _mockRepository;

        public ProdutoServiceTest()
        {
            _mockRepository = new ProdutoMockRepository();
            _produtoService = new ProdutoService(_mockRepository);
        }
    }
}
