namespace ECommerce.Application.DTOs
{
    public record CreateCategoryRequest(string Name);
    public record CategoryDto(int Id, string Name);
}