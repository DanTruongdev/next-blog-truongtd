using System.ComponentModel.DataAnnotations;

namespace BlogOnline.Base
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
