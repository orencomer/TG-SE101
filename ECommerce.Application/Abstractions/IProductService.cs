using ECommerce.Application.DTOs;

namespace ECommerce.Application.Abstractions
{
    public interface IProductService
    {
        Task<ProductDto> CreateAsync(CreateProductRequest request, CancellationToken ct = default);
        Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken ct = default);
        Task<ProductDto?> GetByIdAsync(int id, CancellationToken ct = default);
    }
}