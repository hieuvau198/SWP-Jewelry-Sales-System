using System.ComponentModel.DataAnnotations;

namespace RazorTest.Models
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
        public string GoldCode { get; set; } = "Not Set Yet - from FE";

        [Required]
        public string Unit { get; set; } = "1000đ/Chỉ";
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double SellPrice { get; set; } = 0.0;
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double BuyPrice { get; set; } = 0.0;
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
