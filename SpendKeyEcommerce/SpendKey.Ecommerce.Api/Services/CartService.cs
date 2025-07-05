using Microsoft.EntityFrameworkCore;
using SpendKey.Ecommerce.Api.Data;
using SpendKey.Ecommerce.Api.DTOs;
using SpendKey.Ecommerce.Api.Models;

namespace SpendKey.Ecommerce.Api.Services
{
    public class CartService : ICartService
    {
        private readonly AppDbContext _context;

        public CartService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddToCartAsync(int userId, AddToCartDto request)
        {
            var existingItem = await _context.Carts
                .FirstOrDefaultAsync(c => c.User_Id == userId && c.Product_Id == request.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += request.Quantity;
            }
            else
            {
                _context.Carts.Add(new Cart
                {
                    User_Id = userId,
                    Product_Id = request.ProductId,
                    Quantity = request.Quantity
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<CartDto>> GetCartItemsAsync(int userId)
        {
            return await _context.Carts
                .Where(c => c.User_Id == userId)
                .Include(c => c.Product)
                .Select(c => new CartDto
                {
                    ProductId = c.Product_Id,
                    ProductName = c.Product.Name,
                    Price = c.Product.Price,
                    Quantity = c.Quantity
                })
                .ToListAsync();
        }
    }

}
