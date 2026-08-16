using System;
using System.Collections.Generic;

namespace MetDashboard.Data.Models;

public partial class Financialsummary
{
    public int PropertyId { get; set; }

    public string Address { get; set; } = null!;

    public decimal TotalRent { get; set; }

    public decimal TotalMaintenanceCost { get; set; }
}
