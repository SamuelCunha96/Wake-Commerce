using Wake.Commerce.Domain.Base;

namespace Wake.Commerce.Infrastructure.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : EntidadeBase
    {
        IQueryable<T> GetQuery();
        Task<T?> GetByIdAsync(object? id);
        Task AddAsync(List<T> entity);
        Task AddAsync(T entity);
        Task UpdateAsync(T entidade);
        Task DeleteAsync(T entidade);
    }
}
