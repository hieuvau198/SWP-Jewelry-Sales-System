using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RazorTest.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string InvoiceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string InvoiceType { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CustomerVoucher { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal EndTotalPrice { get; set; }
    }
}
