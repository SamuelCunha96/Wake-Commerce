using AutoMapper;
using Wake.Commerce.Business.Features.Produtos.Commands.CriarProduto;
using Wake.Commerce.Domain.Entities;

namespace Wake.Commerce.Business.AutoMapper
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<CriarProdutoCommand, Produto>();
        }
    }
}
