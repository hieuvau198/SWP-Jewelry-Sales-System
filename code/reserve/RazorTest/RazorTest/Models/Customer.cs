using System.ComponentModel.DataAnnotations;

namespace RazorTest.Models
{
    public class Customer
    {
        [Key]
        public string CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }

        [Required]
        public string CustomerRank { get; set; }

        [Required]
        public int CustomerPoint { get; set; }

        [Required]
        public DateTime AttendDate { get; set; }
    }
}
