using System;
using System.Collections.Generic;

namespace MetDashboard.Data.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Role { get; set; }

    public DateTime? HireDate { get; set; }

    public virtual ICollection<Maintenancerequest> Maintenancerequests { get; set; } = new List<Maintenancerequest>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
