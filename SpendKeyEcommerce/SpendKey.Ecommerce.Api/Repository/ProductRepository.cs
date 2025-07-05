using Microsoft.EntityFrameworkCore;
using SpendKey.Ecommerce.Api.Data;
using SpendKey.Ecommerce.Api.DTOs;

namespace SpendKey.Ecommerce.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) 
        { 
            _context = context;

        }

        public async Task<List<ProductDto>> ListProductsByCategoryId(int categoryId)
        {
            var allCategories = await _context.Categories.ToListAsync();

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
