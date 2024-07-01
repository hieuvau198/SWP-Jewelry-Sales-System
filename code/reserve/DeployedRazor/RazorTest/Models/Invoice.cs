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
        public string CustomerName { get; set; } = "Some Customer Name";
        [Required]
        public string UserId { get; set; }
        public string UserFullname { get; set; } = "Some User Fullname";
        public string ManagerId { get; set; } = "Not yet";
        public string ManagerFullname { get; set; } = "Not yet";
        public string CashierId { get; set; } = "Not yet";
        public string CashierFullname { get; set; } = "Not yet";
        public string StallId { get; set; } = "Not yet";
        public string StallName { get; set; } = "Not yet";
        [Required]
        public DateTime InvoiceDate { get; set; }

        [Required]
        public double CustomerVoucher { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        public double EndTotalPrice { get; set; }
        public string InvoiceStatus { get; set; }
    }
}
