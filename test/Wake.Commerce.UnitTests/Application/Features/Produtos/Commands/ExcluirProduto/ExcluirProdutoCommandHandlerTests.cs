using MediatR;
using Moq;
using Wake.Commerce.Application.Features.Produtos.Commands.ExcluirProduto;
using Wake.Commerce.Domain.Entities;
using Wake.Commerce.Infrastructure.Interfaces.Repositories;

namespace Wake.Commerce.UnitTests.Application.Features.Produtos.Commands.ExcluirProduto
{
    public class ExcluirProdutoCommandHandlerTests
    {
        private readonly Mock<IProdutoRepository> _mockRepository;
        private readonly ExcluirProdutoCommandHandler _handler;

        public ExcluirProdutoCommandHandlerTests()
        {
            _mockRepository = new Mock<IProdutoRepository>();
            _handler = new ExcluirProdutoCommandHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task Handle_DeveExcluirProduto_QuandoProdutoExiste()
        {
            // Arrange
            var command = new ExcluirProdutoCommand(1);
            var produto = new Produto { Id = 1, Nome = "Produto", Estoque = 0, Valor = 50m };
            _mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(produto);
            _mockRepository.Setup(r => r.DeleteAsync(It.IsAny<Produto>())).Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command, new CancellationToken());

            // Assert
            Assert.Equal(Unit.Value, result);
            _mockRepository.Verify(r => r.DeleteAsync(It.IsAny<Produto>()), Times.Once);
        }
    }
}
