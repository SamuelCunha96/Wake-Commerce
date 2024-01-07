using MediatR;

namespace Wake.Commerce.Application.Features.Produtos.Commands.EditarProduto
{
    public class EditarProdutoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public short Estoque { get; set; }
        public decimal Valor { get; set; }
    }
}
