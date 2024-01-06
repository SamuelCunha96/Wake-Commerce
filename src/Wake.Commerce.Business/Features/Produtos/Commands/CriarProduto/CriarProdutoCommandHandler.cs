using AutoMapper;
using MediatR;
using Wake.Commerce.Domain.Entities;
using Wake.Commerce.Repository.Interfaces.Repositories;

namespace Wake.Commerce.Business.Features.Produtos.Commands.CriarProduto
{
    public class CriarProdutoCommandHandler : IRequestHandler<CriarProdutoCommand, CriarProdutoCommandVm>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public CriarProdutoCommandHandler(IProdutoRepository produtoRepository, 
            IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<CriarProdutoCommandVm> Handle(CriarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = _mapper.Map<Produto>(request);

            await _produtoRepository.AddAsync(produto);

            return new CriarProdutoCommandVm 
            {
                ProdutoId = produto.Id
            };
        }
    }
}
