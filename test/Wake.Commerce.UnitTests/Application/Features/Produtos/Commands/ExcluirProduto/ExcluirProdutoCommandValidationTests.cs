using Moq;
using Wake.Commerce.Application.Features.Produtos.Commands.ExcluirProduto;
using Wake.Commerce.Domain.Entities;
using Wake.Commerce.Infrastructure.Interfaces.Repositories;

namespace Wake.Commerce.UnitTests.Application.Features.Produtos.Commands.ExcluirProduto
{
    public class ExcluirProdutoCommandValidationTests
    {
        private readonly ExcluirProdutoCommandValidation _validator;
        private readonly Mock<IProdutoRepository> _mockRepository;

        public ExcluirProdutoCommandValidationTests()
        {
            _mockRepository = new Mock<IProdutoRepository>();
            _validator = new ExcluirProdutoCommandValidation(_mockRepository.Object);
        }

        [Fact]
        public void ValidaExcluirProduto_DeveFalhar_QuandoProdutoNaoEncontrado()
        {
            // Arrange
            var command = new ExcluirProdutoCommand(It.IsAny<int>());
            _mockRepository.Setup(m => m.GetQuery()).Returns(new List<Produto>().AsQueryable());

            // Act
            var result = _validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "ProdutoId");
            Assert.Single(result.Errors);
        }
    }
}
