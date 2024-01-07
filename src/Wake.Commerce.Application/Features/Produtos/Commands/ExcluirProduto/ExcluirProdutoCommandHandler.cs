using AutoMapper;
using MediatR;
using Wake.Commerce.Infrastructure.Interfaces.Repositories;

namespace Wake.Commerce.Application.Features.Produtos.Commands.ExcluirProduto
{
    public class ExcluirProdutoCommandHandler : IRequestHandler<ExcluirProdutoCommand, Unit>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ExcluirProdutoCommandHandler(IProdutoRepository produtoRepository, 
            IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ExcluirProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByIdAsync(request.ProdutoId);

            if (produto != null)
                await _produtoRepository.DeleteAsync(produto);

            return Unit.Value;
        }
    }
}
