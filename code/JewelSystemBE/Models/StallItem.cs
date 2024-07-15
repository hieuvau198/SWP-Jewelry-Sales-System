using System;
using System.Collections.Generic;

namespace JewelSystemBE.Models;

public partial class StallItem
{
    public string StallItemId { get; set; } = null!;

    public string? StallId { get; set; }

    public string? ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? Quantity { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Stall? Stall { get; set; }
}
