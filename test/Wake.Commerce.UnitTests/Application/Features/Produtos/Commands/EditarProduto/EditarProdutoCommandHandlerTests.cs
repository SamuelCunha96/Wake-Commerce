using AutoMapper;
using MediatR;
using Moq;
using Wake.Commerce.Application.Features.Produtos.Commands.EditarProduto;
using Wake.Commerce.Domain.Entities;
using Wake.Commerce.Infrastructure.Interfaces.Repositories;

namespace Wake.Commerce.UnitTests.Application.Features.Produtos.Commands.EditarProduto
{
    public class EditarProdutoCommandHandlerTests
    {
        private readonly Mock<IProdutoRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly EditarProdutoCommandHandler _handler;

        public EditarProdutoCommandHandlerTests()
        {
            _mockRepository = new Mock<IProdutoRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new EditarProdutoCommandHandler(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Handle_DeveEditarProduto_QuandoProdutoExiste()
        {
            // Arrange
            var command = new EditarProdutoCommand { Id = 1, Nome = "Nome Atualizado", Estoque = 0, Valor = 50m };
            var produto = new Produto { Id = 1, Nome = "Produto", Estoque = 0, Valor = 50m };
            var produtoAtualizado = new Produto { Id = 1, Nome = "Nome Atualizado", Estoque = 10, Valor = 50m };
            _mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(produto);
            _mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Produto>())).Returns(Task.CompletedTask);
            _mockMapper.Setup(m => m.Map(It.IsAny<EditarProdutoCommand>(), It.IsAny<Produto>())).Returns(produtoAtualizado);

            // Act
            var result = await _handler.Handle(command, new CancellationToken());

            // Assert
            Assert.Equal(Unit.Value, result);
            Assert.Equal(command.Nome, produtoAtualizado.Nome);
            _mockRepository.Verify(r => r.UpdateAsync(It.IsAny<Produto>()), Times.Once);
        }
    }
}
