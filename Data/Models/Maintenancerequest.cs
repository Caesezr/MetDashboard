using System;
using System.Collections.Generic;

namespace MetDashboard.Data.Models;

public partial class Maintenancerequest
{
    public int RequestId { get; set; }

    public int? PropertyId { get; set; }

    public int? TenantId { get; set; }

    public int? EmployeeId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime? RequestDate { get; set; }

    public DateTime? CompletionDate { get; set; }

    public string? Status { get; set; }

    public decimal? Cost { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Property? Property { get; set; }

    public virtual Tenant? Tenant { get; set; }
}
