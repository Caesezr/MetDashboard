using System;
using System.Collections.Generic;

namespace MetDashboard.Data.Models;

public partial class Activelease
{
    public int LeaseId { get; set; }

    public string Address { get; set; } = null!;

    public string? TenantName { get; set; }

    public decimal MonthlyRent { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}
