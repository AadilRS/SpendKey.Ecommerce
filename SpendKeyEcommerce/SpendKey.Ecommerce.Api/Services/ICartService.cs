using SpendKey.Ecommerce.Api.DTOs;

namespace SpendKey.Ecommerce.Api.Services
{
    public interface ICartService
    {
        Task AddToCartAsync(int userId, AddToCartDto request);

        Task<List<CartDto>> GetCartItemsAsync(int userId);
    }
}
