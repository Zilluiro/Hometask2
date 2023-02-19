using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.ViewModels
{
    public class AddRateModel
    {
        [Required]
        [Range(1,5)]
        public int Score { get; set; }
    }
}
