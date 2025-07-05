using SpendKey.Ecommerce.Api.DTOs;
using SpendKey.Ecommerce.Api.Repository;

namespace SpendKey.Ecommerce.Api.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDto>> GetCategoryTreeAsync()
        {
            var allCategories = await _categoryRepository.ListCategories();

            var lookup = allCategories.ToLookup(c => c.Parent_Id);

            List<CategoryDto> BuildTree(int? parentId)
            {
                return lookup[parentId]
                    .Select(c => new CategoryDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Children = BuildTree(c.Id)
                    }).ToList();
            }

            return BuildTree(null); 
        }
    }
}
