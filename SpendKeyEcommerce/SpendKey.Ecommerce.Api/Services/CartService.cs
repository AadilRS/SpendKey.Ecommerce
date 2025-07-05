using SpendKey.Ecommerce.Api.DTOs;
using SpendKey.Ecommerce.Api.Repository;

namespace SpendKey.Ecommerce.Api.Services
{
    public class CartService : ICartService
    {

        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task AddToCartAsync(int userId, AddToCartDto request)
        {

            await _cartRepository.AddToCart(userId,request);
        }

        public async Task<List<CartDto>> GetCartItemsAsync(int userId)
        {
            return await _cartRepository.ListCartItems(userId);
        }
    }

}
