using Microsoft.EntityFrameworkCore;
using SpendKey.Ecommerce.Api.Data;
using SpendKey.Ecommerce.Api.DTOs;

namespace SpendKey.Ecommerce.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> GetCategoryTreeAsync()
        {
            var allCategories = await _context.Categories.ToListAsync();

            var lookup = allCategories.ToLookup(c => c.Parent_Id);

            List<CategoryDto> BuildTree(int? parentId)
            {
                return lookup[parentId]
                    .Select(c => new CategoryDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Children = BuildTree(c.Id)
                    }).ToList();
            }

            return BuildTree(null); // Start from root categories
        }
    }
}
