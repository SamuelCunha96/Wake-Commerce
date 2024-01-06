using MediatR;

namespace Wake.Commerce.Business.Features.Produtos.Commands.CriarProduto
{
    public class CriarProdutoCommand : IRequest<CriarProdutoCommandVm>
    {
        public string Nome { get; set; } = string.Empty;
        public short Estoque { get; set; }
        public decimal Valor { get; set; }
    }
}
