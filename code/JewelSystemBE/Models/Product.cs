using System;
using System.Collections.Generic;

namespace JewelSystemBE.Models;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string? ProductCode { get; set; }

    public string? ProductName { get; set; }

    public string? ProductImages { get; set; }

    public int ProductQuantity { get; set; }

    public string? ProductType { get; set; }

    public decimal? ProductWeight { get; set; }

    public int? ProductWarranty { get; set; }

    public decimal? MarkupRate { get; set; }

    public string? GemId { get; set; }

    public string? GoldId { get; set; }

    public string? GemName { get; set; }

    public string? GoldName { get; set; }

    public decimal? BuyPrice { get; set; }

    public decimal? GemWeight { get; set; }

    public decimal? GoldWeight { get; set; }

    public decimal? LaborCost { get; set; }

    public decimal? TotalPrice { get; set; }

    public decimal? UnitPrice { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();

    public virtual Gem? Gem { get; set; }

    public virtual Gold? Gold { get; set; }

    public virtual ICollection<StallItem> StallItems { get; set; } = new List<StallItem>();
}
