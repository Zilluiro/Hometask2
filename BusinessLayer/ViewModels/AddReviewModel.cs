using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.ViewModels
{
    public class AddReviewModel
    {
        [Required]
        [MaxLength(512)]
        public string Message { get; set; }

        [Required]
        [MaxLength(64)]
        public string Reviewer { get; set; }
    }
}
