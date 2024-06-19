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

        [Required]
        public double GoldPrice { get; set; } = 0;
    }
}
