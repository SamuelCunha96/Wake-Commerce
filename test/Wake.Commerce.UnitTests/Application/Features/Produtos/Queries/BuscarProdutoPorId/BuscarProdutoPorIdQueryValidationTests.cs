using Moq;
using Wake.Commerce.Application.Features.Produtos.Queries.BuscarProdutoPorId;
using Wake.Commerce.Domain.Entities;
using Wake.Commerce.Infrastructure.Interfaces.Repositories;

namespace Wake.Commerce.UnitTests.Application.Features.Produtos.Queries.BuscarProdutoPorId
{
    public class BuscarProdutoPorIdQueryValidationTests
    {
        private readonly BuscarProdutoPorIdQueryValidation _validator;
        private readonly Mock<IProdutoRepository> _mockRepository;

        public BuscarProdutoPorIdQueryValidationTests()
        {
            _mockRepository = new Mock<IProdutoRepository>();
            _validator = new BuscarProdutoPorIdQueryValidation(_mockRepository.Object);
        }

        [Fact]
        public void ValidaBuscaProdutoPorId_DeveFalhar_QuandoProdutoNaoEncontrado()
        {
            // Arrange
            var command = new BuscarProdutoPorIdQuery(It.IsAny<int>());
            _mockRepository.Setup(m => m.GetQuery()).Returns(new List<Produto>().AsQueryable());

            // Act
            var result = _validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "ProdutoId");
            Assert.Single(result.Errors);
        }

        [Fact]
        public void ValidaBuscaProdutoPorId_DeveNaoPossuirErros_QuandoProdutoExiste()
        {
            // Arrange
            var command = new BuscarProdutoPorIdQuery(1);
            var produto = new Produto { Id = 1, Nome = "Produto", Estoque = 100, Valor = 100 };
            _mockRepository.Setup(m => m.GetQuery()).Returns(new List<Produto> { produto }.AsQueryable());

            // Act
            var result = _validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }
    }
}
