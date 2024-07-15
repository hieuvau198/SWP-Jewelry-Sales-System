using System.ComponentModel.DataAnnotations;

namespace JewelBO
{
    public class Warranty
    {
        [Key]
        public string WarrantyId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string ProductId { get; set; } = "Some Product Id";

        [Required]
        public string ProductName { get; set; } = "Some Product Name";

        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime ExpireDate { get; set; } = DateTime.Now;
    }
}
