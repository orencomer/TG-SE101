using ECommerce.Application.Abstractions;
using ECommerce.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAll(CancellationToken ct)
            => Ok(await _productService.GetAllAsync(ct));

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductRequest request, CancellationToken ct)
        {
            var created = await _productService.CreateAsync(request, ct);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetById([FromRoute][Range(1, int.MaxValue)] int id, CancellationToken ct)
        {
            var dto = await _productService.GetByIdAsync(id, ct);
            if (dto is null)
                return NotFound(new { message = $"Product {id} not found" });
            return Ok(dto);
        }
    }
}