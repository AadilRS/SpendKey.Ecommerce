using Microsoft.EntityFrameworkCore;
using SpendKey.Ecommerce.Api.Data;
using SpendKey.Ecommerce.Api.DTOs;
using SpendKey.Ecommerce.Api.Models;

namespace SpendKey.Ecommerce.Api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository (AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> ListCategories()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
