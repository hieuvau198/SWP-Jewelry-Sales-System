using System;
using System.Collections.Generic;

namespace JewelSystemBE.Models;

public partial class Stall
{
    public string StallId { get; set; } = null!;

    public string? StallName { get; set; }

    public string? UserId { get; set; }

    public string? StaffName { get; set; }

    public string? StallDescription { get; set; }

    public string? StallType { get; set; }

    public virtual ICollection<StallEmployee> StallEmployees { get; set; } = new List<StallEmployee>();

    public virtual ICollection<StallItem> StallItems { get; set; } = new List<StallItem>();

    public virtual User? User { get; set; }
}
