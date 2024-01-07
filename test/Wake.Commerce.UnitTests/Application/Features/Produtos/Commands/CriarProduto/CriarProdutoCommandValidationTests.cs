using Wake.Commerce.Application.Features.Produtos.Commands.CriarProduto;

namespace Wake.Commerce.UnitTests.Application.Features.Produtos.Commands.CriarProduto
{
    public class CriarProdutoCommandValidationTests
    {
        private readonly CriarProdutoCommandValidation _validator;

        public CriarProdutoCommandValidationTests()
        {
            _validator = new CriarProdutoCommandValidation();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("Esta é uma string muito longa que certamente tem mais de cinquenta caracteres para testar a validação.")]
        public void ValidaCriarProduto_DeveFalhar_QuandoNomeEhInvalido(string nomeInvalido)
        {
            // Arrange
            var command = new CriarProdutoCommand { Nome = nomeInvalido, Estoque = 10, Valor = 100m };

            // Act
            var result = _validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Nome");
        }

        [Theory]
        [InlineData(-1)]
        public void ValidaCriarProduto_DeveFalhar_QuandoEstoqueEhInvalido(short estoque)
        {
            // Arrange
            var command = new CriarProdutoCommand { Nome = "Nome", Estoque = estoque, Valor = 100m };

            // Act
            var result = _validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Estoque");
        }

        [Theory]
        [InlineData(-1)]
        public void ValidaCriarProduto_DeveFalhar_QuandoValorProdutoEhInvalido(decimal valor)
        {
            // Arrange
            var command = new CriarProdutoCommand { Nome = "Nome", Estoque = 100, Valor = valor };

            // Act
            var result = _validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Valor");
        }
    }

}
