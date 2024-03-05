using System;
using System.Collections.Generic;

namespace Data;

public partial class MontoTotalTransaccionado
{
    public string? IdCompany { get; set; }

    public string CompanyName { get; set; } = null!;

    public DateTime TransactionDate { get; set; }

    public decimal? TotalAmount { get; set; }
}
