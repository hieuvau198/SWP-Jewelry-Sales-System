using System;
using System.Collections.Generic;

namespace JewelSystemBE.Models;

public partial class Gold
{
    public string GoldId { get; set; } = null!;

    public string? GoldName { get; set; }

    public string? Unit { get; set; }

    public string? GoldCode { get; set; }

    public decimal? BuyPrice { get; set; }

    public decimal? SellPrice { get; set; }

    public DateOnly? Date { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
