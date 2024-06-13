using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JewelSystemBE.Model
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(50)]
        public string ProductCode { get; set; } = "Some Product Code";

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; } = "Some Product Name";

        [Required]
        [MaxLength(200)]
        public string ProductImages { get; set; } = "Some Product Image";

        [Required]
        public int ProductQuantity { get; set; } = 0;

        [Required]
        [MaxLength(100)]
        public string ProductType { get; set; } = "None";

        [Required]
        public double ProductWeight { get; set; }

        [Required]
        public int ProductWarranty { get; set; } = 0;

        [Required]
        public double MarkupRate { get; set; } = 1;

        // Gem properties
        [Required]
        public string GemId { get; set; } = "Some Gem Id";

        [Required]
        public double GemWeight { get; set; } = 0.0;

        // Gold properties
        [Required]
        public string GoldId { get; set; } = "Some Gold Id";

        [Required]
        public double GoldWeight { get; set; } = 0.0;

        [Required]
        public double LaborCost { get; set; } = 0.0;

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
