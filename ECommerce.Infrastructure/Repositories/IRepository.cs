using System.Linq.Expressions;

namespace ECommerce.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity, CancellationToken ct = default);
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct = default, params Expression<Func<T, object>>[] includes);
        Task<T?> GetByIdAsync(object id, CancellationToken ct = default, params Expression<Func<T, object>>[] includes);
    }
}