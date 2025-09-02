namespace ECommerce.Application.DTOs
{
    public record CreateProductRequest(string Name, decimal Price, int Stock, int CategoryId);
    public record ProductDto(int Id, string Name, decimal Price, int Stock, int CategoryId, string CategoryName);
}