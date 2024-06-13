using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using JewelBO;

namespace RazorTest.Models
{
    public class InvoiceItem
    {
        public string InvoiceItemId { get; set; }

        public string InvoiceId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; } = 0.0;

        public string DiscountId { get; set; }

        public double DiscountRate { get; set; } = 0.0;

        public double TotalPrice { get; set; } = 0.0;

        public double EndTotalPrice { get; set; } = 0.0;

        public string WarrantyId { get; set; }
    }
}
