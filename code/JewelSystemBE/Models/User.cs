using System;
using System.Collections.Generic;

namespace JewelSystemBE.Models;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<StallEmployee> StallEmployees { get; set; } = new List<StallEmployee>();

    public virtual ICollection<Stall> Stalls { get; set; } = new List<Stall>();
}
