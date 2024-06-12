using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RazorTest.Models;

namespace JewelBO
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductImages { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductType { get; set; }
        public double ProductWeight { get; set; }
        public int ProductWarranty { get; set; } // Months
        public float MarkupRate { get; set; }
        public string GemId { get; set; }
        public double GemWeight { get; set; }
        public string GoldId { get; set; }
        public double GoldWeight { get; set; }
        public double LaborCost { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
