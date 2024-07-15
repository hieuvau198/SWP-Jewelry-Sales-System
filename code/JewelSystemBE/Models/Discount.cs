using System;
using System.Collections.Generic;

namespace JewelSystemBE.Models;

public partial class Discount
{
    public string DiscountId { get; set; } = null!;

    public string? DiscountName { get; set; }

    public string? OrderType { get; set; }

    public string? ProductType { get; set; }

    public DateOnly? PublicDate { get; set; }

    public string? ProductId { get; set; }

    public decimal? DiscountRate { get; set; }

    public DateOnly? ExpireDate { get; set; }

    public virtual Product? Product { get; set; }
}
