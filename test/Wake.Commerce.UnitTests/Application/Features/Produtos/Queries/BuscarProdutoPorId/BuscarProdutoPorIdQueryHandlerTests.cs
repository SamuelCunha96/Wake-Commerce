using AutoMapper;
using Moq;
using Wake.Commerce.Application.Features.Produtos.Queries.BuscarProdutoPorId;
using Wake.Commerce.Domain.Entities;
using Wake.Commerce.Infrastructure.Interfaces.Repositories;

namespace Wake.Commerce.UnitTests.Application.Features.Produtos.Queries.BuscarProdutoPorId
{
    public class BuscarProdutoPorIdQueryHandlerTests
    {
        private readonly Mock<IProdutoRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly BuscarProdutoPorIdQueryHandler _handler;

        public BuscarProdutoPorIdQueryHandlerTests()
        {
            _mockRepository = new Mock<IProdutoRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new BuscarProdutoPorIdQueryHandler(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Handle_RetornaProdutoEncontrado_QuandoProdutoExiste()
        {
            // Arrange
            var command = new BuscarProdutoPorIdQuery(It.IsAny<int>());
            var produto = new Produto { Id = 1, Nome = "Produto", Estoque = 0, Valor = 50m };
            var produtoVm = new BuscarProdutoPorIdQueryVm { Id = 1, Nome = "Produto", Estoque = 0, Valor = 50m };

            _mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(produto);
            _mockMapper.Setup(m => m.Map<BuscarProdutoPorIdQueryVm>(It.IsAny<Produto>())).Returns(produtoVm);

            // Act
            var result = await _handler.Handle(command, new CancellationToken());

            // Assert
            Assert.NotNull(result);
        }
    }
}
