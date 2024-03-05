using System;
using System.Collections.Generic;

namespace Data;

public partial class Company
{
    public string IdCompany { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public virtual ICollection<Charge> Charges { get; set; } = new List<Charge>();
}
