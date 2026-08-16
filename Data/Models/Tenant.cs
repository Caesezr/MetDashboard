using System;
using System.Collections.Generic;

namespace MetDashboard.Data.Models;

public partial class Tenant
{
    public int TenantId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Employer { get; set; }

    public string? EmergencyContact { get; set; }

    public virtual ICollection<Lease> Leases { get; set; } = new List<Lease>();

    public virtual ICollection<Maintenancerequest> Maintenancerequests { get; set; } = new List<Maintenancerequest>();
}
