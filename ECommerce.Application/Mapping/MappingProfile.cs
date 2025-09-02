using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category != null ? s.Category.Name : ""));
            CreateMap<CreateProductRequest, Product>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryRequest, Category>();
        }
    }
}