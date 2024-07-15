using System.ComponentModel.DataAnnotations;

namespace JewelBO
{
    public class Discount
    {
        [Key]
        [Required]
        public string DiscountId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(200)]
        public string DiscountName { get; set; } = "Just Some Discount";

        [Required]
        [MaxLength(200)]
        public string OrderType { get; set; } = "All";

        [Required]
        [MaxLength(200)]
        public string ProductType { get; set; } = "All";
        [Required]
        public string ProductId { get; set; } = "All";

        [Required]
        public double DiscountRate { get; set; } = 0.0;

        [Required]
        public DateTime PublicDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime ExpireDate { get; set; } = DateTime.Now;
    }
}
