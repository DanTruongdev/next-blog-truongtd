using BlogOnline.Models.DTOs.Requests;
using BlogOnline.Models.DTOs.Responses;
using BlogOnline.Models.Entities;
using System.Linq.Expressions;

namespace BlogOnline.Services
{
    public interface IBlogService
    {
        public Task<BlogRes> GetBlogByIdAsync(Guid id);
     
        public Task<IEnumerable<BlogRes>> GetAllBlogsAsync();
        public Task<Blog> AddBlogAsync(BlogDto form);
        public Task<bool> UpdateBlogAsync(BlogDto form);
        public Task<bool> RemoveBlogAsync(Guid id);
        public Task<IEnumerable<BlogRes>> SearchBlogAsync(string searchString);
    }
}
