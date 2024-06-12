using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RazorTest.Models;

namespace JewelBO
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProductId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ProductCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(200)]
        public string ProductImages { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Product quantity must be greater than 0.")]
        public int ProductQuantity { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductType { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Product weight must be greater than 0.")]
        public double ProductWeight { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Product warranty must be a non-negative integer.")]
        public int ProductWarranty { get; set; } // Months

        [Required]
        [Range(0.0, double.MaxValue, ErrorMessage = "Markup rate must be a non-negative value.")]
        public float MarkupRate { get; set; }

        [Required]
        [ForeignKey("Gem")]
        public string GemId { get; set; }
        public Gem Gem { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Gem weight must be greater than 0.")]
        public double GemWeight { get; set; }

        [Required]
        [ForeignKey("Gold")]
        public string GoldId { get; set; }
        public Gold Gold { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Gold weight must be greater than 0.")]
        public double GoldWeight { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Labor cost must be a non-negative value.")]
        public decimal LaborCost { get; set; } = 0m;

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
