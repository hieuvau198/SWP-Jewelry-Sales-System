using System;
using System.Collections.Generic;

namespace JewelSystemBE.Models;

public partial class StallEmployee
{
    public string StallEmployeeId { get; set; } = null!;

    public string? StallId { get; set; }

    public string? StallName { get; set; }

    public string? EmployeeId { get; set; }

    public string? EmployeeFullname { get; set; }

    public string? Role { get; set; }

    public virtual User? Employee { get; set; }

    public virtual Stall? Stall { get; set; }
}
