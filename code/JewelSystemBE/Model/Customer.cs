using System.ComponentModel.DataAnnotations;

namespace JewelSystemBE.Model
{
    public class Customer
    {
        [Key]
        public string CustomerId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string CustomerName { get; set; } = "Some Customer";
        [Required]
        public string CustomerPhone { get; set; } = "Some Phone Contact";

        [Required]
        public string CustomerRank { get; set; } = "Some Rank";

        [Required]
        public int CustomerPoint { get; set; } = 0;

        [Required]
        public DateTime AttendDate { get; set; } = DateTime.Now;
    }
}
