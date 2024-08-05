using BlogOnline.Models.DTOs.Responses;
using BlogOnline.Models.Entities;

namespace BlogOnline.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryRes>> GetAllCategoryAsync();
    }
}
