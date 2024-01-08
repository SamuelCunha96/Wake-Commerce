using MediatR;
using Wake.Commerce.Shared.Enums;

namespace Wake.Commerce.Application.Features.Produtos.Queries.ListarProdutos
{
    public class ListarProdutosQuery : IRequest<List<ListarProdutosQueryVm>>
    {
        public ListarProdutosQuery(string? nome, TipoOrdenacaoProduto? tipoOrdenacao)
        {
            Nome = nome;
            TipoOrdenacao = tipoOrdenacao;
        }

        public string? Nome { get; private set; }
        public TipoOrdenacaoProduto? TipoOrdenacao { get; private set; }
    }
}
