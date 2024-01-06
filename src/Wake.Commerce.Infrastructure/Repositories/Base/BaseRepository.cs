using Microsoft.EntityFrameworkCore;
using Wake.Commerce.Domain.Base;
using Wake.Commerce.Infrastructure.Context;
using Wake.Commerce.Infrastructure.Interfaces.Repositories.Base;

namespace Wake.Commerce.Infrastructure.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : EntidadeBase
    {
        public virtual WakeCommerceContext Context { get; private set; }

        public BaseRepository(WakeCommerceContext context)
        {
            Context = context;
        }

        protected DbSet<T> EntitySet => Context.Set<T>();

        public IQueryable<T> GetQuery()
        {
            return EntitySet.AsQueryable();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await EntitySet.AsQueryable().ToListAsync();
        }

        public async Task AddAsync(T entity) 
        {
            await EntitySet.AddAsync(entity);

            await Context.SaveChangesAsync();
        }

        public async Task AddAsync(List<T> entity)
        {
            await EntitySet.AddRangeAsync(entity);

            await Context.SaveChangesAsync();
        }
    }
}
