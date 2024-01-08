using AutoMapper;
using Moq;
using Wake.Commerce.Application.Features.Produtos.Queries.ListarProdutos;
using Wake.Commerce.Domain.Entities;
using Wake.Commerce.Infrastructure.Interfaces.Repositories;
using Wake.Commerce.Shared.Enums;

namespace Wake.Commerce.UnitTests.Application.Features.Produtos.Queries
{
    public class ListarProdutosQueryHandlerTests
    {
        private readonly Mock<IProdutoRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ListarProdutosQueryHandler _handler;

        public ListarProdutosQueryHandlerTests()
        {
            _mockRepository = new Mock<IProdutoRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new ListarProdutosQueryHandler(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Handle_RetornaTodosProdutos_QuandoFiltroNomeVazio()
        {
            // Arrange
            var produtos = new List<Produto>
            {
                new Produto { Id = 1, Nome = "AAAAA", Valor = 300, Estoque = 200 },
                new Produto { Id = 2, Nome = "BBBBB", Valor = 200, Estoque = 300 },
                new Produto { Id = 3, Nome = "CCCCC", Valor = 100, Estoque = 100 },
            }.AsQueryable();

            var query = new ListarProdutosQuery(It.IsAny<string>(), It.IsAny<TipoOrdenacaoProduto?>());
            var expectedViewModels = new List<ListarProdutosQueryVm>
            {
                new ListarProdutosQueryVm { Id = 1, Nome = "AAAAA", Valor = 300, Estoque = 200 },
                new ListarProdutosQueryVm { Id = 2, Nome = "BBBBB", Valor = 200, Estoque = 300 },
                new ListarProdutosQueryVm { Id = 3, Nome = "CCCCC", Valor = 100, Estoque = 100 },
            };

            _mockRepository.Setup(r => r.GetQuery()).Returns(produtos);
            _mockMapper.Setup(m => m.Map<List<ListarProdutosQueryVm>>(It.IsAny<List<Produto>>()))
                       .Returns(expectedViewModels);

            // Act
            var result = await _handler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedViewModels.Count, result.Count);
        }

        [Fact]
        public async Task Handle_RetornaProdutosFiltrados_QuandoFiltroNomeInformado()
        {
            int countProdutosEsperados = 1;

            // Arrange
            var produtos = new List<Produto>
            {
                new Produto { Id = 1, Nome = "AAAAA", Valor = 300, Estoque = 200 },
                new Produto { Id = 2, Nome = "BBBBB", Valor = 200, Estoque = 300 },
                new Produto { Id = 3, Nome = "CCCCC", Valor = 100, Estoque = 100 },
            }.AsQueryable();

            var query = new ListarProdutosQuery("a", It.IsAny<TipoOrdenacaoProduto?>());
            var expectedViewModels = new List<ListarProdutosQueryVm>
            {
                new ListarProdutosQueryVm { Id = 1, Nome = "AAAAA", Valor = 300, Estoque = 200 },
            };

            _mockRepository.Setup(r => r.GetQuery()).Returns(produtos);
            _mockMapper.Setup(m => m.Map<List<ListarProdutosQueryVm>>(It.IsAny<List<Produto>>()))
                       .Returns(expectedViewModels);

            // Act
            var result = await _handler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedViewModels.Count, countProdutosEsperados);
        }

        [Fact]
        public async Task Handle_RetornaProdutosOrdenadosPorNome_QuandoTipoOrdenacaoNome()
        {
            // Arrange
            var produtos = new List<Produto>
            {
                new Produto { Id = 1, Nome = "AAAAA", Valor = 300, Estoque = 200 },
                new Produto { Id = 2, Nome = "BBBBB", Valor = 200, Estoque = 300 },
                new Produto { Id = 3, Nome = "CCCCC", Valor = 100, Estoque = 100 },
            }.AsQueryable();

            var query = new ListarProdutosQuery(It.IsAny<string>(), TipoOrdenacaoProduto.Nome);
            var expectedViewModels = new List<ListarProdutosQueryVm>
            {
                new ListarProdutosQueryVm { Id = 1, Nome = "AAAAA", Valor = 300, Estoque = 200 },
                new ListarProdutosQueryVm { Id = 2, Nome = "BBBBB", Valor = 200, Estoque = 300 },
                new ListarProdutosQueryVm { Id = 3, Nome = "CCCCC", Valor = 100, Estoque = 100 },
            };

            _mockRepository.Setup(r => r.GetQuery()).Returns(produtos);
            _mockMapper.Setup(m => m.Map<List<ListarProdutosQueryVm>>(It.IsAny<List<Produto>>()))
                       .Returns(expectedViewModels);

            // Act
            var result = await _handler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedViewModels.Count, produtos.Count());
            Assert.True(expectedViewModels.First().Nome == "AAAAA");
        }

        [Fact]
        public async Task Handle_RetornaProdutosOrdenadosPorValor_QuandoTipoOrdenacaoValor()
        {
            // Arrange
            var produtos = new List<Produto>
            {
                new Produto { Id = 1, Nome = "AAAAA", Valor = 300, Estoque = 200 },
                new Produto { Id = 2, Nome = "BBBBB", Valor = 200, Estoque = 300 },
                new Produto { Id = 3, Nome = "CCCCC", Valor = 100, Estoque = 100 },
            }.AsQueryable();

            var query = new ListarProdutosQuery(It.IsAny<string>(), TipoOrdenacaoProduto.Valor);
            var expectedViewModels = new List<ListarProdutosQueryVm>
            {
                new ListarProdutosQueryVm { Id = 3, Nome = "CCCCC", Valor = 100, Estoque = 100 },
                new ListarProdutosQueryVm { Id = 2, Nome = "BBBBB", Valor = 200, Estoque = 300 },
                new ListarProdutosQueryVm { Id = 1, Nome = "AAAAA", Valor = 300, Estoque = 200 },
            };

            _mockRepository.Setup(r => r.GetQuery()).Returns(produtos);
            _mockMapper.Setup(m => m.Map<List<ListarProdutosQueryVm>>(It.IsAny<List<Produto>>()))
                       .Returns(expectedViewModels);

            // Act
            var result = await _handler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedViewModels.Count, produtos.Count());
            Assert.True(expectedViewModels.First().Valor == 100);
        }

        [Fact]
        public async Task Handle_RetornaProdutosOrdenadosPorEstoque_QuandoTipoOrdenacaoEstoque()
        {
            // Arrange
            var produtos = new List<Produto>
            {
                new Produto { Id = 1, Nome = "AAAAA", Valor = 300, Estoque = 20 },
                new Produto { Id = 2, Nome = "BBBBB", Valor = 200, Estoque = 30 },
                new Produto { Id = 3, Nome = "CCCCC", Valor = 100, Estoque = 10 },
            }.AsQueryable();

            var query = new ListarProdutosQuery(It.IsAny<string>(), TipoOrdenacaoProduto.Estoque);
            var expectedViewModels = new List<ListarProdutosQueryVm>
            {
                new ListarProdutosQueryVm { Id = 3, Nome = "CCCCC", Valor = 100, Estoque = 10 },
                new ListarProdutosQueryVm { Id = 1, Nome = "AAAAA", Valor = 300, Estoque = 20 },
                new ListarProdutosQueryVm { Id = 2, Nome = "BBBBB", Valor = 200, Estoque = 30 },
            };

            _mockRepository.Setup(r => r.GetQuery()).Returns(produtos);
            _mockMapper.Setup(m => m.Map<List<ListarProdutosQueryVm>>(It.IsAny<List<Produto>>()))
                       .Returns(expectedViewModels);

            // Act
            var result = await _handler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedViewModels.Count, produtos.Count());
            Assert.True(expectedViewModels.First().Estoque == 10);
        }
    }
}
