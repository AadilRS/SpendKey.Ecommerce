using SpendKey.Ecommerce.Api.DTOs;

namespace SpendKey.Ecommerce.Api.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetCategoryTreeAsync();
    }
}
