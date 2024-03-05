using System;
using System.Collections.Generic;

namespace Data;

public partial class Charge
{
    public string IdCharge { get; set; } = null!;

    public string? IdCompany { get; set; }

    public decimal Amount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? PaidAt { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }
}
