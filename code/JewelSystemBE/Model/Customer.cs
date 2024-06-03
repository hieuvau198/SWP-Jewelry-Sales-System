using System.ComponentModel.DataAnnotations;

namespace JewelSystemBE.Model
{
    public class Customer
    {
        [Key]
        public string CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerRank { get; set; }

        [Required]
        public int CustomerPoint { get; set; }

        [Required]
        public DateTime AttendDate { get; set; }
    }
}
