using SpendKey.Ecommerce.Api.DTOs;

namespace SpendKey.Ecommerce.Api.Services
{
    public interface IProductService
    {
       Task<List<ProductDto>> GetProductsByCategoryAsync(int categoryId);
    }
}
