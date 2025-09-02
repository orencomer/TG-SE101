using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Persistence;

namespace ECommerce.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDbContext _ctx;

        public UnitOfWork(ECommerceDbContext ctx)
        {
            _ctx = ctx;
        }

        private IRepository<Product>? _products;
        private IRepository<Category>? _categories;

        public IRepository<Product> Products => _products ??= new Repository<Product>(_ctx);
        public IRepository<Category> Categories => _categories ??= new Repository<Category>(_ctx);
    }
}