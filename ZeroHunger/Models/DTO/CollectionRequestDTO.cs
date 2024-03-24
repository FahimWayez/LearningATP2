using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.Models.DTO
{
    public class CollectionRequestDTO
    {
        [Required]
        [Display(Name = "Food Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Beneficial for [hour(s)]")]
        [Range(1, int.MaxValue, ErrorMessage = "Hours must be greater than 0")]
        public int ExpireTime { get; set; }
        [Required]
        [Display(Name = "Amount [kg(s)]")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than or equal to 0.01")]
        public double Amount { get; set; }
    }
}