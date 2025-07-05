using SpendKey.Ecommerce.Api.Models;

namespace SpendKey.Ecommerce.Api.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> ListCategories();
    }
}
