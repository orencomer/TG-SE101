using AutoMapper;
using ECommerce.Application.Abstractions;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Repositories;

namespace ECommerce.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryRequest request, CancellationToken ct = default)
        {
            var entity = _mapper.Map<Category>(request);
            await _uow.Categories.AddAsync(entity, ct);
            var withCategory = await _uow.Categories.GetByIdAsync(entity.Id, ct);
            return _mapper.Map<CategoryDto>(withCategory ?? entity);
        }

        public async Task<IReadOnlyList<CategoryDto>> GetAllAsync(CancellationToken ct = default)
        {
            var list = await _uow.Categories.GetAllAsync(ct);
            return _mapper.Map<IReadOnlyList<CategoryDto>>(list);
        }

        public async Task<CategoryDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _uow.Categories.GetByIdAsync(id, ct);
            return entity is null ? null : _mapper.Map<CategoryDto>(entity);
        }
    }
}