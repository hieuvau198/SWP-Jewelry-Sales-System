using System.ComponentModel.DataAnnotations;

namespace JewelSystemBE.Model
{
    public class Gem
    {
        [Key]
        [Required]
        [StringLength(100)]
        public string GemId { get; set; }

        [Required]
        [StringLength(200)]
        public string GemName { get; set; }

        [Required]
        [Range(0, (double)decimal.MaxValue)]
        public decimal GemPrice { get; set; }
    }
}
