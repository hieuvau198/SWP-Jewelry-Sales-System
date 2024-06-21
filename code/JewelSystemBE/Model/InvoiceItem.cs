using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JewelSystemBE.Model
{
    public class InvoiceItem
    {
        [Key]
        public string InvoiceItemId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string InvoiceId { get; set; } = "Some Invoice Id";

        [Required]
        public string ProductId { get; set; } = "Some ProductId";

        [Required]
        public string ProductName { get; set; } = "Some Product Name";
        [Required]
        public string StallId { get; set; } = "Some Stall Id";
        [Required]
        public string StallName { get; set; } = "Some Stall Name";

        [Required]
        public int Quantity { get; set; } = 1;

        [Required]
        public double UnitPrice { get; set; } = 0.0;

        [Required]
        public string DiscountId { get; set; } = "Some Discount Id";

        [Required]
        public double DiscountRate { get; set; } = 0.0;

        [Required]
        public double TotalPrice { get; set; } = 0.0;

        [Required]
        public double EndTotalPrice { get; set; } = 0.0;

        [Required]
        public string WarrantyId { get; set; } = "Some Warranty Id";
    }
}
