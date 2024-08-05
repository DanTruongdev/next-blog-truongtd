using BlogOnline.Base;
using BlogOnline.Models.Entities;

namespace BlogOnline.Models.DTOs.Responses
{
    public class CategoryRes : BaseEntity
    {
        public string? Name { get; set; }
        public List<Blog>? Blogs { get; set; }
    }
}
