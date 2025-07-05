using Microsoft.AspNetCore.Mvc;
using SpendKey.Ecommerce.Api.DTOs;
using SpendKey.Ecommerce.Api.Services;

namespace SpendKey.Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryTree()
        {
            var tree = await _categoryService.GetCategoryTreeAsync();
            return Ok(tree);
        }
    }
}
