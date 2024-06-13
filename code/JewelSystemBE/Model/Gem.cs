using System.ComponentModel.DataAnnotations;

namespace JewelSystemBE.Model
{
    public class Gem
    {
        [Key]
        [Required]
        [StringLength(100)]
        public string GemId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(200)]
        public string GemName { get; set; } = "Some Gem";

        [Required]
        public double GemPrice { get; set; } = 0.0;
    }
}
