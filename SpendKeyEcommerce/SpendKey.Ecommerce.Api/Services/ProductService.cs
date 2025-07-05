using Microsoft.EntityFrameworkCore;
using SpendKey.Ecommerce.Api.Data;
using SpendKey.Ecommerce.Api.DTOs;

namespace SpendKey.Ecommerce.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> GetProductsByCategoryAsync(int categoryId)
        {
            var allCategories = await _context.Categories.ToListAsync();

            // Recursive helper to collect all category IDs
            List<int> CollectCategoryIds(int parentId)
            {
                var children = allCategories.Where(c => c.Parent_Id == parentId).ToList();
                var ids = children.Select(c => c.Id).ToList();
                foreach (var child in children)
                {
                    ids.AddRange(CollectCategoryIds(child.Id));
                }
                return ids;
            }

            var categoryIds = new List<int> { categoryId };
            categoryIds.AddRange(CollectCategoryIds(categoryId));

            var products = await _context.Products
                .Where(p => categoryIds.Contains(p.Category_Id))
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    AvailabilityQty = p.Availability_Qty
                })
                .ToListAsync();

            return products;
        }
    }

}
