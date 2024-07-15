using System;
using System.Collections.Generic;

namespace JewelSystemBE.Models;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string? CustomerName { get; set; }

    public string? CustomerRank { get; set; }

    public int? CustomerPoint { get; set; }

    public DateOnly? AttendDate { get; set; }

    public string? CustomerPhone { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
