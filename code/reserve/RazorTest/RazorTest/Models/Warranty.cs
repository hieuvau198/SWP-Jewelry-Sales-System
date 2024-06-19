using System.ComponentModel.DataAnnotations;

namespace RazorTest.Models
{
    public class Warranty
    {
        [Key]
        public string WarrantyId { get; set; }

        [Required]
        public string ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }
    }
}
