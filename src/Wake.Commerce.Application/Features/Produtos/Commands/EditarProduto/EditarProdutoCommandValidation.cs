using FluentValidation;
using Wake.Commerce.Infrastructure.Interfaces.Repositories;

namespace Wake.Commerce.Application.Features.Produtos.Commands.EditarProduto
{
    public class EditarProdutoCommandValidation : AbstractValidator<EditarProdutoCommand>
    {
        private readonly IProdutoRepository _produtoRepository;

        public EditarProdutoCommandValidation(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do produto é obrigatório")
                .MaximumLength(50)
                .WithMessage("O nome do produto deve possuir no máximo 50 caracteres");

            RuleFor(x => x.Valor)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor do produto deve ser maior ou igual a 0");

            RuleFor(x => x.Estoque)
                .GreaterThanOrEqualTo((short)0)
                .WithMessage("O valor do produto deve ser maior ou igual a 0");

            RuleFor(x => x.Id)
                .Must(produtoId => ProdutoExiste(produtoId))
                .WithMessage(command => $"O produto com o id '{command.Id}' não existe na base dados");
        }

        private bool ProdutoExiste(int produtoId) 
        {
            return _produtoRepository.GetQuery().Any(x => x.Id == produtoId);
        }
    }
}
