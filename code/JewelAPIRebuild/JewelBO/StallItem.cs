using System.ComponentModel.DataAnnotations;

namespace JewelBO
{
    public class StallItem
    {
        [Key]
        public string StallItemId { get; set; } = Guid.NewGuid().ToString();

        public string StallId { get; set; } = "Some Stall ID";
        [Required]
        public string ProductId { get; set; } = "Some Product Id";
        [Required]
        public string ProductName { get; set; } = "Some Product Name";
        [Required]
        public int quantity { get; set; } = 0;
    }
}
