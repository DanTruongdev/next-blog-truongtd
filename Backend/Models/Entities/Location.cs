using BlogOnline.Base;
using System.ComponentModel.DataAnnotations;

namespace BlogOnline.Models.Entities
{
    public class Location : BaseEntity
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The location name must be between 2 and 100 characters")]
        public string Name { get; set; }
        //navigation prop
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
