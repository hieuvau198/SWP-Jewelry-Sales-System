using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using JewelBO;

namespace RazorTest.Models
{
    public class InvoiceItem
    {
        [Key]
        [Required]
        public string InvoiceItemId { get; set; }

        [Required]
        [ForeignKey("Invoice")]
        public string InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Required]
        public string DiscountId { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? DiscountRate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal EndTotalPrice { get; set; }

        [Required]
        [ForeignKey("Warranty")]
        public string WarrantyId { get; set; }
        public Warranty Warranty { get; set; }
    }
}
