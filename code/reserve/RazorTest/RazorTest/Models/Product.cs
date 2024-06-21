using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RazorTest.Models;

namespace RazorTest.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductImages { get; set; }
        public int ProductQuantity { get; set; } = 1;
        public string ProductType { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double ProductWeight { get; set; }
        public int ProductWarranty { get; set; } // Months
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double MarkupRate { get; set; } = 1;
        public string GemId { get; set; }
        public string GemName { get; set; } = "Some Gem Name";
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double GemWeight { get; set; } = 1;
        public string GoldId { get; set; }
        public string GoldName { get; set; } = "Some Gold Name";
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double GoldWeight { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double LaborCost { get; set; } = 5;
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double UnitPrice { get; set; } = 1.3;
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double TotalPrice { get; set; } = 1;
        public DateTime CreatedAt { get; set; }
    }
}
