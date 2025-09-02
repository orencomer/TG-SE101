using AutoMapper;
using ECommerce.Application.Abstractions;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Repositories;

namespace ECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateAsync(CreateProductRequest request, CancellationToken ct = default)
        {
            var entity = _mapper.Map<Product>(request);
            await _uow.Products.AddAsync(entity, ct);
            var withCategory = await _uow.Products.GetByIdAsync(entity.Id, ct, p => p.Category!);
            return _mapper.Map<ProductDto>(withCategory ?? entity);
        }

        public async Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken ct = default)
        {
            var list = await _uow.Products.GetAllAsync(ct, p => p.Category!);
            return _mapper.Map<IReadOnlyList<ProductDto>>(list);
        }

        public async Task<ProductDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _uow.Products.GetByIdAsync(id, ct, p => p.Category!);
            return entity is null ? null : _mapper.Map<ProductDto>(entity);
        }
    }
}