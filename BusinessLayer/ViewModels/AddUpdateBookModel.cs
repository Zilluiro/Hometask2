using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.ViewModels
{
    public class AddUpdateBookModel
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        public string Cover { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [MaxLength(64)]
        public string Genre { get; set; }

        [Required]
        [MaxLength(32)]
        public string Author { get; set; }
    }
}
