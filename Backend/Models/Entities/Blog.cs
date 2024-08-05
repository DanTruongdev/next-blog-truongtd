using BlogOnline.Base;
using System.ComponentModel.DataAnnotations;

namespace BlogOnline.Models.Entities
{
    public class Blog : BaseEntity
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The blog title must be between 2 and 50 characters")]
        public string Title { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The blog short description must be between 2 and 100 characters")]
        public string? ShortDescription { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "The blog content must be greater than 10 characters")]
        public string Content { get; set; }
        public string? Image { get; set; } = string.Empty;
        [Required]
        public Guid LocationId { get; set; }
        [Required]
        public bool IsPublic { get; set; } = true;
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public DateTime PublictDate { get; set; } = DateTime.Now;

        //navigation prop
        public virtual Category? Category { get; set; }
        public virtual Location? Location { get; set; }
    }
}
