using System.ComponentModel.DataAnnotations;

namespace BlogOnline.Models.DTOs.Requests
{
    public class BlogDto
    {
        public Guid? Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The blog title must be between 2 and 50 characters")]
        public string Title { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The blog short description must be between 2 and 100 characters")]
        public string? ShortDescription { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "The blog content must be greater than 10 characters")]
        public string Content { get; set; }
        public IFormFile? Image { get; set; }
        [Required]
        public Guid LocationId { get; set; }
        [Required]
        public bool IsPublic { get; set; } 
        [Required]
        public Guid CategoryId { get; set; }
        public DateTime? PublicDate { get; set; }
    }
}
