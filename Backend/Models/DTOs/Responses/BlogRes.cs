using BlogOnline.Base;
using BlogOnline.Models.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace BlogOnline.Models.DTOs.Responses
{
    public class BlogRes:BaseEntity
    {
        public string? Title { get; set; }
        public string? ShortDescription { get; set; } = string.Empty;
        public string Content { get; set; }
        public string? Image { get; set; } = string.Empty;
        public LocationRes? Location { get; set; }
        public bool? IsPublic { get; set; }
        public CategoryRes? Category { get; set; }
        public DateTime? PublicDate { get; set; }
    }
}
