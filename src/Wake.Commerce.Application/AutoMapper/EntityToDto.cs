using AutoMapper;
using Wake.Commerce.Application.Features.Produtos.Commands.CriarProduto;
using Wake.Commerce.Application.Features.Produtos.Commands.EditarProduto;
using Wake.Commerce.Domain.Entities;

namespace Wake.Commerce.Application.AutoMapper
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<CriarProdutoCommand, Produto>();
            CreateMap<EditarProdutoCommand, Produto>();
        }
    }
}
