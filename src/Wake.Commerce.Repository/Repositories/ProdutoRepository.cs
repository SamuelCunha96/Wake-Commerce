using Wake.Commerce.Domain.Entities;
using Wake.Commerce.Repository.Context;
using Wake.Commerce.Repository.Interfaces.Repositories;
using Wake.Commerce.Repository.Repositories.Base;

namespace Wake.Commerce.Repository.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(WakeCommerceContext context) : base(context)
        {
        }
    }
}
