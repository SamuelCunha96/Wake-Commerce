using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Wake.Commerce.Infrastructure.Interfaces.Repositories;

namespace Wake.Commerce.Application.Features.Produtos.Queries.BuscarProdutoPorId
{
    public class BuscarProdutoPorIdQueryValidation : AbstractValidator<BuscarProdutoPorIdQuery>
    {
        private readonly IProdutoRepository _produtoRepository;

        public BuscarProdutoPorIdQueryValidation(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;

            RuleFor(x => x.ProdutoId)
                .Must(produtoId => ProdutoExiste(produtoId))
                .WithMessage(command => $"O produto com o id '{command.ProdutoId}' não existe na base dados");
        }

        private bool ProdutoExiste(int produtoId)
        {
            return _produtoRepository.GetQuery().AsNoTracking().Any(x => x.Id == produtoId);
        }
    }
}
