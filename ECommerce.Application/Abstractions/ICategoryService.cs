using ECommerce.Application.DTOs;

namespace ECommerce.Application.Abstractions
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateAsync(CreateCategoryRequest request, CancellationToken ct = default);
        Task<IReadOnlyList<CategoryDto>> GetAllAsync(CancellationToken ct = default);
        Task<CategoryDto?> GetByIdAsync(int id, CancellationToken ct = default);
    }
}