using System;
using System.Collections.Generic;

namespace JewelSystemBE.Models;

public partial class Warranty
{
    public string WarrantyId { get; set; } = null!;

    public string? ProductId { get; set; }

    public string? ProductName { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? ExpireDate { get; set; }

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
}
