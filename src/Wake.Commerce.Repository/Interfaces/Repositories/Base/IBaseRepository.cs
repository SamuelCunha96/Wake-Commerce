using Wake.Commerce.Domain.Base;

namespace Wake.Commerce.Repository.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : EntidadeBase
    {
        IQueryable<T> GetQuery();
        Task<IReadOnlyList<T>> GetAllAsync();
        Task AddAsync(List<T> entity);
        Task AddAsync(T entity);
    }
}
