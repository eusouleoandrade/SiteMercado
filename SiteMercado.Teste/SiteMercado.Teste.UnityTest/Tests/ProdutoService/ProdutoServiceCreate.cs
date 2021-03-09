using SiteMercado.Teste.Application.Exceptions;
using SiteMercado.Teste.Domain.Entities;
using Xunit;

namespace SiteMercado.Teste.UnityTest.Tests
{
    public class ProdutoServiceCreate : ProdutoServiceTest
    {
        [Fact]
        public void CheckCreate()
        {
            // Arranje
            Produto newProduto = new Produto("ProdutoX", 15.60M);

            // Act
            _produtoService.CreateProduto(newProduto);

            // Assert
            var expectedProduto = _mockRepository.GetByNome(newProduto.Nome);
            Assert.NotNull(expectedProduto);
            Assert.Equal(expectedProduto.Nome, newProduto.Nome);
            Assert.Equal(expectedProduto.Valor, newProduto.Valor);
        }

        [Fact]
        public void CheckCreateWithExceptionReturn()
        {
            // Arranje
            Produto newProduto = new Produto("ProdutoA", 15.60M);

            // Act
            void act() => _produtoService.CreateProduto(newProduto);

            // Assert
            string expectedMessage = $"{nameof(Produto)} já cadastrado";
            ServiceException exception = Assert.Throws<ServiceException>(act);
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
