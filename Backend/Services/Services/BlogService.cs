using BlogOnline.Base;
using BlogOnline.Extentions;
using BlogOnline.Models.DTOs.Requests;
using BlogOnline.Models.DTOs.Responses;
using BlogOnline.Models.Entities;
using System.Linq.Expressions;

namespace BlogOnline.Services.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBaseRepository<Blog> _blogRepository;

        public BlogService(IBaseRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Blog> AddBlogAsync(BlogDto form)
        {
            var newBlog = new Blog()
            {
                Title = form.Title,
                ShortDescription = form.ShortDescription,
                Content = form.Content,
                Image = FileHelper.UploadFile(form.Image),
                LocationId = form.LocationId,
                IsPublic = form.IsPublic,
                CategoryId = form.CategoryId,
                PublictDate = form.PublicDate.Value,
            };
            try
            {
                var addResult = await _blogRepository.AddAsync(newBlog);
                return addResult;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<IEnumerable<BlogRes>> GetAllBlogsAsync()
        {
            var blogs = await _blogRepository.GetAllAsync();
            if (!blogs.Any()) return new List<BlogRes>();
            var response = blogs.Select(b => new BlogRes
            {
                Id = b.Id,
                Title = b.Title,
                ShortDescription = b.ShortDescription,
                Content = b.Content,
                Image = b.Image,
                Location = new LocationRes
                {
                    Id = b.LocationId,
                    Name = b.Location.Name
                },
                IsPublic = b.IsPublic,
                Category = new CategoryRes
                {
                    Id = b.Category.Id,
                    Name = b.Category.Name
                },
                PublicDate = b.PublictDate
            });
            return response;
        }

        public async Task<BlogRes> GetBlogByIdAsync(Guid id)
        {
            Blog blog = await _blogRepository.GetByIdAsync(id);
            var blogRes = new BlogRes
            {
                Id = blog.Id,
                Title = blog.Title,
                ShortDescription = blog.ShortDescription,
                Content = blog.Content,
                Image = blog.Image,
                Location = new LocationRes
                {
                    Id = blog.LocationId,
                    Name = blog.Location.Name
                },
                IsPublic = blog.IsPublic,
                Category = new CategoryRes
                {
                    Id = blog.Category.Id,
                    Name = blog.Category.Name
                },
                PublicDate = blog.PublictDate
            };
            return blogRes;
        }

        public async Task<bool> RemoveBlogAsync(Guid id)
        {

            try
            {
                var deleteBlog = await _blogRepository.GetByIdAsync(id);
                if (deleteBlog == null) return false;
                var deleteResult = await _blogRepository.RemoveAsync(deleteBlog);
                FileHelper.RemoveFile(deleteBlog.Image);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<BlogRes>> SearchBlogAsync(string searchString)
        {
            var searchResult = await _blogRepository.SearchAsync(b => b.Title.Contains(searchString));
            if (!searchResult.Any()) return new List<BlogRes>();
            var returnData = searchResult.Select(b => new BlogRes
            {
                Id = b.Id,
                Title = b.Title,
                ShortDescription = b.ShortDescription,
                Content = b.Content,
                Image = b.Image,
                Location = new LocationRes
                {
                    Id = b.LocationId,
                    Name = b.Location.Name
                },
                IsPublic = b.IsPublic,
                Category = new CategoryRes
                {
                    Id = b.Category.Id,
                    Name = b.Category.Name
                },
                PublicDate = b.PublictDate

            });
            return returnData;
        }

        public async Task<bool> UpdateBlogAsync(BlogDto form)
        {

            try
            {
                var blogExisting = await _blogRepository.GetByIdAsync(form.Id.Value);
                if (blogExisting == null) return false;
                if (form.Image != null) FileHelper.RemoveFile(blogExisting.Image);
                blogExisting.Title = form.Title;
                blogExisting.ShortDescription = form.ShortDescription;
                blogExisting.Content = form.Content;
                blogExisting.Image = FileHelper.UploadFile(form.Image);
                blogExisting.LocationId = form.LocationId;
                blogExisting.IsPublic = form.IsPublic;
                blogExisting.CategoryId = form.CategoryId;
                blogExisting.PublictDate = form.PublicDate.HasValue ? form.PublicDate.Value : DateTime.Now;
                var updateResult = await _blogRepository.UpdateAsync(blogExisting);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
