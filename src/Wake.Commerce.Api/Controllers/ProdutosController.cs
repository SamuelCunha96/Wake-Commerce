using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wake.Commerce.Application.Features.Produtos.Commands.CriarProduto;
using Wake.Commerce.Application.Features.Produtos.Commands.EditarProduto;
using Wake.Commerce.Application.Features.Produtos.Commands.ExcluirProduto;

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

        // GET: api/<ProdutosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarProdutoCommand request)
        {
            var retorno = await _mediator.Send(request);

            return Ok(retorno);
        }

        // PUT api/<ProdutosController>
        [HttpPut()]
        public async Task<IActionResult> PutAsync([FromBody] EditarProdutoCommand request)
        {
            await _mediator.Send(request);

            return NoContent();
        }

        // DELETE api/<ProdutosController>/2
        [HttpDelete("{produtoId}")]
        public async Task<IActionResult> DeleteAsync(int produtoId)
        {
            await _mediator.Send(new ExcluirProdutoCommand(produtoId));

            return NoContent();
        }
    }
}
