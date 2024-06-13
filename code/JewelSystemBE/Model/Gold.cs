using System.ComponentModel.DataAnnotations;

namespace JewelSystemBE.Model
{
    public class Gold
    {
        [Key]
        [Required]
        [StringLength(100)]
        public string GoldId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(200)]
        public string GoldName { get; set; } = "Some Gold";

        [Required]
        public double GoldPrice { get; set; } = 0.0;
    }
}
