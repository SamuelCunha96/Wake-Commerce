using MediatR;

namespace Wake.Commerce.Application.Features.Produtos.Commands.ExcluirProduto
{
    public class ExcluirProdutoCommand : IRequest<Unit>
    {
        public ExcluirProdutoCommand(int produtoId)
        {
            ProdutoId = produtoId;
        }

        public int ProdutoId { get; private set; }
    }
}
