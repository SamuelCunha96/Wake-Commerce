using MediatR;
using Wake.Commerce.Infrastructure.Interfaces.Repositories;

namespace Wake.Commerce.Application.Features.Produtos.Commands.ExcluirProduto
{
    public class ExcluirProdutoCommandHandler : IRequestHandler<ExcluirProdutoCommand, Unit>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ExcluirProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Unit> Handle(ExcluirProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByIdAsync(request.ProdutoId);

            await _produtoRepository.DeleteAsync(produto);

            return Unit.Value;
        }
    }
}
