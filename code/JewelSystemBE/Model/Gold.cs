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
        public string GoldCode { get; set; } = "Some Gold Code";
        [Required]
        public string Unit { get; set; } = "VND/Chỉ";
        [Required]
        public double SellPrice { get; set; } = 0.0;
        [Required]
        public double BuyPrice { get; set; } = 0.0;
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
