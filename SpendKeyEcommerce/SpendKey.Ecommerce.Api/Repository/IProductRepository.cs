using SpendKey.Ecommerce.Api.DTOs;

namespace SpendKey.Ecommerce.Api.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> ListProductsByCategoryId(int categoryId);
    }
}
