using Wake.Commerce.Domain.Entities;
using Wake.Commerce.Infrastructure.Context;
using Wake.Commerce.Infrastructure.Interfaces.Repositories;
using Wake.Commerce.Infrastructure.Repositories.Base;

namespace Wake.Commerce.Infrastructure.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(WakeCommerceContext context) : base(context)
        {
        }
    }
}
