using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Review: BaseEntity
    {
        [Required]
        public int BookId { get; set; }

        [Required]
        [MaxLength(512)]
        public string Message { get; set; } = string.Empty;

        [Required]
        [MaxLength(64)]
        public string Reviewer { get; set; } = string.Empty;

        public Book? Book { get; set; }
    }
}
