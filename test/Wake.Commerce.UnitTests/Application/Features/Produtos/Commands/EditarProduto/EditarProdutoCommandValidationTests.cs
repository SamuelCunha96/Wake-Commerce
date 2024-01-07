using Moq;
using Wake.Commerce.Application.Features.Produtos.Commands.EditarProduto;
using Wake.Commerce.Domain.Entities;
using Wake.Commerce.Infrastructure.Interfaces.Repositories;

namespace Wake.Commerce.UnitTests.Application.Features.Produtos.Commands.EditarProduto
{
    public class EditarProdutoCommandValidationTests
    {
        private readonly EditarProdutoCommandValidation _validator;
        private readonly Mock<IProdutoRepository> _mockRepository;

        public EditarProdutoCommandValidationTests()
        {
            _mockRepository = new Mock<IProdutoRepository>();
            _validator = new EditarProdutoCommandValidation(_mockRepository.Object);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("Esta é uma string muito longa que certamente tem mais de cinquenta caracteres para testar a validação.")]
        public void ValidaEditarProduto_DeveFalhar_QuandoNomeEhInvalido(string nomeInvalido)
        {
            // Arrange
            var command = new EditarProdutoCommand { Id = 1, Nome = nomeInvalido, Estoque = 10, Valor = 100m };
            var produto = new Produto { Id = 1, Nome = "Produto", Estoque = 100, Valor = 100m };
            _mockRepository.Setup(m => m.GetQuery()).Returns(new List<Produto> { produto }.AsQueryable());

            // Act
            var result = _validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Nome");
            Assert.Single(result.Errors);
        }

        [Theory]
        [InlineData(-1)]
        public void ValidaEditarProduto_DeveFalhar_QuandoEstoqueEhInvalido(short estoque)
        {
            // Arrange
            var command = new EditarProdutoCommand { Id = 1, Nome = "Nome", Estoque = estoque, Valor = 100m };
            var produto = new Produto { Id = 1, Nome = "Produto", Estoque = 100, Valor = 100m };
            _mockRepository.Setup(m => m.GetQuery()).Returns(new List<Produto> { produto }.AsQueryable());

            // Act
            var result = _validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Estoque");
            Assert.Single(result.Errors);
        }

        [Theory]
        [InlineData(-1)]
        public void ValidaEditarProduto_DeveFalhar_QuandoValorProdutoEhInvalido(decimal valor)
        {
            // Arrange
            var command = new EditarProdutoCommand { Id = 1, Nome = "Teste", Estoque = 100, Valor = valor };
            var produto = new Produto { Id = 1, Nome = "Produto", Estoque = 100, Valor = valor };
            _mockRepository.Setup(m => m.GetQuery()).Returns(new List<Produto> { produto }.AsQueryable());
            
            // Act
            var result = _validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Valor");
            Assert.Single(result.Errors);
        }

        [Fact]
        public void ValidaEditarProduto_DeveFalhar_QuandoProdutoNaoEncontrado()
        {
            // Arrange
            var command = new EditarProdutoCommand { Id = 1, Nome = "Nome", Estoque = 100, Valor = 100 };
            _mockRepository.Setup(m => m.GetQuery()).Returns(new List<Produto>().AsQueryable());

            // Act
            var result = _validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Id");
            Assert.Single(result.Errors);
        }
    }

}
