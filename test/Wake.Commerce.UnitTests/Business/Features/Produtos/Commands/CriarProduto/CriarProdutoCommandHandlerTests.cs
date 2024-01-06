using AutoMapper;
using Moq;
using Wake.Commerce.Business.Features.Produtos.Commands.CriarProduto;
using Wake.Commerce.Domain.Entities;
using Wake.Commerce.Repository.Interfaces.Repositories;

namespace Wake.Commerce.UnitTests.Business.Features.Produtos.Commands.CriarProduto
{
    public class CriarProdutoCommandHandlerTests
    {
        private readonly Mock<IProdutoRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CriarProdutoCommandHandler _handler;

        public CriarProdutoCommandHandlerTests()
        {
            _mockRepository = new Mock<IProdutoRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new CriarProdutoCommandHandler(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Handle_DeveCriarProduto_QuandoCommandEhValido()
        {
            // Arrange
            var command = new CriarProdutoCommand { Nome = "Teste", Estoque = 10, Valor = 100m };
            var produto = new Produto { Id = 1, Nome = "Teste", Estoque = 10, Valor = 100m };
            _mockMapper.Setup(m => m.Map<Produto>(It.IsAny<CriarProdutoCommand>())).Returns(produto);
            _mockRepository.Setup(r => r.AddAsync(It.IsAny<Produto>())).Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(produto.Id, result.ProdutoId);
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<Produto>()), Times.Once);
        }
    }

}
