using System.ComponentModel.DataAnnotations;

namespace JewelBO
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
        public string GemCode { get; set; } = "Some Gem Code";
        public string Unit { get; set; } = "ct";
        public double BuyPrice { get; set; } = 0.0;

        [Required]
        public double GemPrice { get; set; } = 0.0;
        public double GemWeight { get; set; } = 0.0;
    }
}
