using SpendKey.Ecommerce.Api.DTOs;

namespace SpendKey.Ecommerce.Api.Repository
{
    public interface ICartRepository
    {
        Task AddToCart(int userId, AddToCartDto request);

        Task<List<CartDto>> ListCartItems(int userId);
    }
}
