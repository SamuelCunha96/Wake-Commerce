using AutoMapper;
using MediatR;
using Wake.Commerce.Domain.Entities;
using Wake.Commerce.Infrastructure.Interfaces.Repositories;

namespace Wake.Commerce.Application.Features.Produtos.Commands.EditarProduto
{
    public class EditarProdutoCommandHandler : IRequestHandler<EditarProdutoCommand, Unit>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public EditarProdutoCommandHandler(IProdutoRepository produtoRepository, 
            IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EditarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByIdAsync(request.Id);

            produto = _mapper.Map<Produto>(request);

            if (produto != null)
                await _produtoRepository.UpdateAsync(produto);
            
            return Unit.Value;
        }
    }
}
