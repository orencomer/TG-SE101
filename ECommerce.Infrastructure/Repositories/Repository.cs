using ECommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ECommerceDbContext _ctx;

        public Repository(ECommerceDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<T?> GetByIdAsync(object id, CancellationToken ct = default, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> q = _ctx.Set<T>();
            foreach (var include in includes) q = q.Include(include);
            var entity = await q.FirstOrDefaultAsync(e => EF.Property<object>(e, "Id")!.Equals(id), ct);
            return entity;
        }

        public async Task<T> AddAsync(T entity, CancellationToken ct = default)
        {
            _ctx.Set<T>().Add(entity);
            await _ctx.SaveChangesAsync(ct);
            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct = default, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _ctx.Set<T>();
            foreach (var include in includes) query = query.Include(include);
            return await query.AsNoTracking().ToListAsync(ct);
        }
    }
}