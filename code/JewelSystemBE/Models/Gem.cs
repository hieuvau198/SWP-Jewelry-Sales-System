using System;
using System.Collections.Generic;

namespace JewelSystemBE.Models;

public partial class Gem
{
    public string GemId { get; set; } = null!;

    public string? GemName { get; set; }

    public string? GemCode { get; set; }

    public string? Unit { get; set; }

    public decimal? GemWeight { get; set; }

    public decimal? BuyPrice { get; set; }

    public decimal? GemPrice { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
