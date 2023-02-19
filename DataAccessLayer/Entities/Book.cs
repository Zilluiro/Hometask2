using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Book: BaseEntity
    {
        [Required]
        [MaxLength(128)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(256)]
        public string Cover { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        [MaxLength(64)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [MaxLength(32)]
        public string Genre { get; set; } = string.Empty;

        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Rating>? Ratings { get; set; }
    }
}
