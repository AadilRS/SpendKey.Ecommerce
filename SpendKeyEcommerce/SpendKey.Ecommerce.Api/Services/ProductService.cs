using SpendKey.Ecommerce.Api.Data;
using SpendKey.Ecommerce.Api.DTOs;
using SpendKey.Ecommerce.Api.Repository;

namespace SpendKey.Ecommerce.Api.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> GetProductsByCategoryAsync(int categoryId)
        {
            return await  _productRepository.ListProductsByCategoryId(categoryId);
        }
    }

}
