using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wake.Commerce.Application.Features.Produtos.Commands.CriarProduto;
using Wake.Commerce.Application.Features.Produtos.Commands.EditarProduto;
using Wake.Commerce.Application.Features.Produtos.Commands.ExcluirProduto;
using Wake.Commerce.Application.Features.Produtos.Queries.ListarProdutos;
using Wake.Commerce.Shared.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wake.Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Listar os produtos
        /// </summary>
        /// <param name="nome">Nome do produto</param>
        /// <param name="tipoOrdenacao">Ordenar por: [0= Nome]; [1=Valor]; [3=Estoque]</param>
        /// <returns>fdsfsd</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] string? nome, TipoOrdenacaoProduto tipoOrdenacao)
        {
            var retorno = await _mediator.Send(new ListarProdutosQuery(nome, tipoOrdenacao));
            
            return Ok(retorno);
        }

        //// GET api/<ProdutosController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        /// <summary>
        /// Criar produto
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ID do produto criado</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarProdutoCommand request)
        {
            var retorno = await _mediator.Send(request);

            return Ok(retorno);
        }

        /// <summary>
        /// Editar produto
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task<IActionResult> PutAsync([FromBody] EditarProdutoCommand request)
        {
            await _mediator.Send(request);

            return NoContent();
        }

        /// <summary>
        /// Excluir produto
        /// </summary>
        /// <param name="produtoId"></param>
        /// <returns></returns>
        [HttpDelete("{produtoId}")]
        public async Task<IActionResult> DeleteAsync(int produtoId)
        {
            await _mediator.Send(new ExcluirProdutoCommand(produtoId));

            return NoContent();
        }
    }
}
