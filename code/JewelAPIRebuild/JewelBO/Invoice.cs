﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JewelBO
{
    public class Invoice
    {
        [Key]
        public string InvoiceId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(50)]
        public string InvoiceType { get; set; } = "Sale";

        [Required]
        public string CustomerId { get; set; } = "Some Customer Id";
        [Required]
        public string CustomerName { get; set; } = "Some Customer Name";

        [Required]
        public string UserId { get; set; } = "Some User Id";
        [Required]
        public string UserFullname { get; set; } = "Some User Fullname";
        public string ManagerId { get; set; } = "Not yet";
        public string ManagerFullname { get; set; } = "Not yet";
        public string CashierId { get; set; } = "Not yet";
        public string CashierFullname { get; set; } = "Not yet";
        public string StallId { get; set; } = "Not yet";
        public string StallName { get; set; } = "Not yet";

        [Required]
        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        [Required]
        public double CustomerVoucher { get; set; } = 0.0;

        [Required]
        public double TotalPrice { get; set; } = 0.0;

        [Required]
        public double EndTotalPrice { get; set; } = 0.0;

        [Required]
        public string InvoiceStatus { get; set; } = "Pending";
    }
}
