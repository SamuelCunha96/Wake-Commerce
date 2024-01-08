using MediatR;

namespace Wake.Commerce.Application.Features.Produtos.Queries.BuscarProdutoPorId
{
    public class BuscarProdutoPorIdQuery : IRequest<BuscarProdutoPorIdQueryVm>
    {
        public int ProdutoId { get; private set; }

        public BuscarProdutoPorIdQuery(int produtoId)
        {
            ProdutoId = produtoId;
        }
    }
}
