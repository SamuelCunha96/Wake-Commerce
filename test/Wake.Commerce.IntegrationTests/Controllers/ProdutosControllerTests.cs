using Newtonsoft.Json;
using System.Net;
using System.Text;
using Wake.Commerce.Business.Features.Produtos.Commands.CriarProduto;
using Wake.Commerce.IntegrationTests.Factory;

namespace Wake.Commerce.IntegrationTests.Controllers
{
    public class ProdutosControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ProdutosControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostProduto_ComDadosValidos_DeveRetornarOkEProdutoCriado()
        {
            var requestData = new CriarProdutoCommand { Nome = "Produto", Valor = 100m, Estoque = 100 };
            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Produtos", content);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<CriarProdutoCommandVm>(responseString);

            Assert.NotNull(responseData);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PostProduto_QuandoValorInvalido_DeveRetornarBadRequest()
        {
            var requestData = new CriarProdutoCommand { Nome = "Produto", Valor = -1, Estoque = 100 };
            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Produtos", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostProduto_QuandoEstoqueInvalido_DeveRetornarBadRequest()
        {
            var requestData = new CriarProdutoCommand { Nome = "Produto", Valor = 10m, Estoque = -1 };
            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Produtos", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
