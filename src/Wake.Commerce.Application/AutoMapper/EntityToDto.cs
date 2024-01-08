using AutoMapper;
using Wake.Commerce.Application.Features.Produtos.Commands.CriarProduto;
using Wake.Commerce.Application.Features.Produtos.Commands.EditarProduto;
using Wake.Commerce.Application.Features.Produtos.Queries.BuscarProdutoPorId;
using Wake.Commerce.Application.Features.Produtos.Queries.ListarProdutos;
using Wake.Commerce.Domain.Entities;

namespace Wake.Commerce.Application.AutoMapper
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<CriarProdutoCommand, Produto>();
            CreateMap<EditarProdutoCommand, Produto>();
            CreateMap<Produto, ListarProdutosQueryVm>();
            CreateMap<Produto, BuscarProdutoPorIdQueryVm>();
        }
    }
}
