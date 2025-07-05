using Microsoft.AspNetCore.Mvc;
using SpendKey.Ecommerce.Api.DTOs;
using SpendKey.Ecommerce.Api.Services;

namespace SpendKey.Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto request)
        {
            int userId = 1; // for demo hardcoding the value, in a complete flow it will be done by authentication token
            await _cartService.AddToCartAsync(userId, request);
            return Ok(new { message = "Product added to cart." });
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            int userId = 1; // hardcoded for now
            var cartItems = await _cartService.GetCartItemsAsync(userId);
            return Ok(cartItems);
        }
    }

}
