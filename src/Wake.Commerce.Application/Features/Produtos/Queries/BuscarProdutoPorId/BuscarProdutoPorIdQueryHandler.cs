using AutoMapper;
using MediatR;
using Wake.Commerce.Infrastructure.Interfaces.Repositories;

namespace Wake.Commerce.Application.Features.Produtos.Queries.BuscarProdutoPorId
{
    public class BuscarProdutoPorIdQueryHandler : IRequestHandler<BuscarProdutoPorIdQuery, BuscarProdutoPorIdQueryVm>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public BuscarProdutoPorIdQueryHandler(IProdutoRepository produtoRepository, 
            IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<BuscarProdutoPorIdQueryVm> Handle(BuscarProdutoPorIdQuery request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByIdAsync(request.ProdutoId);

            return _mapper.Map<BuscarProdutoPorIdQueryVm>(produto);
        }
    }
}
