using ECommerce.Application.Abstractions;
using ECommerce.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CategoryDto>>> GetAll(CancellationToken ct)
            => Ok(await _categoryService.GetAllAsync(ct));

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CreateCategoryRequest request, CancellationToken ct)
        {
            var created = await _categoryService.CreateAsync(request, ct);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDto>> GetById([FromRoute][Range(1, int.MaxValue)] int id, CancellationToken ct)
        {
            var dto = await _categoryService.GetByIdAsync(id, ct);
            if (dto is null)
                return NotFound(new { message = $"Category {id} not found" });
            return Ok(dto);
        }
    }
}