using ECommerce.Domain.Entities;

namespace ECommerce.Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
    }
}