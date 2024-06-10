using System.ComponentModel.DataAnnotations;

namespace JewelBO
{
    public class Gold
    {
        [Key]
        [Required]
        [StringLength(100)]
        public string GoldId { get; set; }

        [Required]
        [StringLength(200)]
        public string GoldName { get; set; }

        [Required]
        [Range(0, (double)decimal.MaxValue)]
        public decimal GoldPrice { get; set; }
    }
}
