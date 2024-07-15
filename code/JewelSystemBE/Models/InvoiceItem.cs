using System;
using System.Collections.Generic;

namespace JewelSystemBE.Models;

public partial class InvoiceItem
{
    public string InvoiceItemId { get; set; } = null!;

    public string? InvoiceId { get; set; }

    public string? ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? Quantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public string? DiscountId { get; set; }

    public decimal? DiscountRate { get; set; }

    public decimal? TotalPrice { get; set; }

    public decimal? EndTotalPrice { get; set; }

    public string? WarrantyId { get; set; }

    public string? StallId { get; set; }

    public string? StallName { get; set; }

    public virtual Invoice? Invoice { get; set; }

    public virtual Warranty? Warranty { get; set; }
}
