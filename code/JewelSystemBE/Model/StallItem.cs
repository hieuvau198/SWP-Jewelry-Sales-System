using System.ComponentModel.DataAnnotations;

namespace JewelSystemBE.Model
{
    public class StallItem
    {
        [Key]
        public string StallItemId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string ProductId { get; set; } = "Some Product Id";
        [Required]
        public string ProductName { get; set; } = "Some Product Name";
        [Required]
        public int quantity { get; set; } = 0;
    }
}
