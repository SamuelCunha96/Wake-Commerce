using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wake.Commerce.Domain.Entities;
using Wake.Commerce.Infrastructure.Interfaces.Repositories;
using Wake.Commerce.Shared.Enums;
using Wake.Commerce.Shared.Extensions;

namespace Wake.Commerce.Application.Features.Produtos.Queries.ListarProdutos
{
    public class ListarProdutosQueryHandler : IRequestHandler<ListarProdutosQuery, List<ListarProdutosQueryVm>>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ListarProdutosQueryHandler(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<List<ListarProdutosQueryVm>> Handle(ListarProdutosQuery request, CancellationToken cancellationToken)
        {
            var query = _produtoRepository.GetQuery();

            if (!request.Nome.IsNull())
                query = query.Where(x => x.Nome.ToUpper().Contains(request.Nome.ToUpper()));

            query = OrdenarPorTipo(query, request.TipoOrdenacao);

            return _mapper.Map<List<ListarProdutosQueryVm>>(await query.ToListAsync());
        }

        private IQueryable<Produto> OrdenarPorTipo(IQueryable<Produto> query, TipoOrdenacaoProduto tipoOrdenacaoProduto)
        {
            return tipoOrdenacaoProduto switch
            {
                TipoOrdenacaoProduto.Nome => query.OrderBy(x => x.Nome),
                TipoOrdenacaoProduto.Valor => query.OrderBy(x => x.Valor),
                TipoOrdenacaoProduto.Estoque => query.OrderBy(x => x.Estoque),
                _ => query.OrderBy(x => x.Nome)
            };
        }
    }
}
