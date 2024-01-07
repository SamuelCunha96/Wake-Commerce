﻿using Newtonsoft.Json;
using System.Net;
using System.Text;
using Wake.Commerce.Application.Features.Produtos.Commands.CriarProduto;
using Wake.Commerce.Application.Features.Produtos.Commands.EditarProduto;
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

        [Fact]
        public async Task PutProduto_ComDadosValidos_DeveRetornarNoContent()
        {
            var requestData = new EditarProdutoCommand { Id = 1,  Nome = "Produto alterado", Valor = 555m, Estoque = 55 };
            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            var response = await _client.PutAsync("/api/Produtos", content);

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task PutProduto_QuandoValorInvalido_DeveRetornarBadRequest()
        {
            var requestData = new CriarProdutoCommand { Nome = "Produto A", Valor = -1, Estoque = 100 };
            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            var response = await _client.PutAsync("/api/Produtos", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PutProduto_QuandoEstoqueInvalido_DeveRetornarBadRequest()
        {
            var requestData = new CriarProdutoCommand { Nome = "Produto A", Valor = 10m, Estoque = -1 };
            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            var response = await _client.PutAsync("/api/Produtos", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
