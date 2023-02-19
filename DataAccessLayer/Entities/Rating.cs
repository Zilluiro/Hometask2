using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Rating: BaseEntity
    {
        [Required]
        public int BookId { get; set; }
        
        [Required]
        public int Score { get; set; }

        public Book? Book { get; set; }
    }
}
