using System;
using System.Collections.Generic;

namespace JewelSystemBE.Models;

public partial class Invoice
{
    public string InvoiceId { get; set; } = null!;

    public string? InvoiceType { get; set; }

    public string? CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? UserId { get; set; }

    public string? UserFullname { get; set; }

    public string? CashierId { get; set; }

    public string? CashierFullname { get; set; }

    public string? ManagerId { get; set; }

    public string? ManagerFullname { get; set; }

    public string? StallId { get; set; }

    public string? StallName { get; set; }

    public DateOnly? InvoiceDate { get; set; }

    public decimal? CustomerVoucher { get; set; }

    public decimal? TotalPrice { get; set; }

    public decimal? EndTotalPrice { get; set; }

    public string? InvoiceStatus { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    public virtual User? User { get; set; }
}
