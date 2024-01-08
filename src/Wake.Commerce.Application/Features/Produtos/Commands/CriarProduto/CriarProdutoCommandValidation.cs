using FluentValidation;

namespace Wake.Commerce.Application.Features.Produtos.Commands.CriarProduto
{
    public class CriarProdutoCommandValidation : AbstractValidator<CriarProdutoCommand>
    {
        public CriarProdutoCommandValidation()
        {
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
        }
    }
}
