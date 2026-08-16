using System;
using System.Collections.Generic;

namespace MetDashboard.Data.Models;

public partial class Lease
{
    public int LeaseId { get; set; }

    public int? PropertyId { get; set; }

    public int? TenantId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal MonthlyRent { get; set; }

    public decimal? SecurityDeposit { get; set; }

    public string? LeaseStatus { get; set; }

    public int DueDay { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Property? Property { get; set; }

    public virtual Tenant? Tenant { get; set; }
}
