using BlogOnline.Base;
using BlogOnline.Models.DTOs.Responses;
using BlogOnline.Models.Entities;
using BlogOnline.Services.Interfaces;

namespace BlogOnline.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category> _categoryRepository;

        public CategoryService(IBaseRepository<Category> blogRepository)
        {
            _categoryRepository = blogRepository;
        }

        public async Task<IEnumerable<CategoryRes>> GetAllCategoryAsync()
        {
            var categoryList = await _categoryRepository.GetAllAsync();
            if (!categoryList.Any()) return new List<CategoryRes>();
            var resData = categoryList.Select(c => new CategoryRes
            {
                Id = c.Id,
                Name = c.Name,
            });
            return resData;
        }
    }
}
