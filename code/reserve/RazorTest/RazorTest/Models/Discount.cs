using System.ComponentModel.DataAnnotations;

namespace RazorTest.Models
{
    public class Discount
    {
        [Key]
        [Required]
        public string DiscountId { get; set; }

        [Required]
        [MaxLength(200)]
        public string DiscountName { get; set; }

        [Required]
        [MaxLength(200)]
        public string OrderType { get; set; }

        [Required]
        [MaxLength(200)]
        public string ProductType { get; set; }
        public string ProductId { get; set; }
        public double DiscountRate { get; set; } 

        [Required]
        public DateTime PublicDate { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }
    }
}
