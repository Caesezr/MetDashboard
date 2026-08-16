using System;
using System.Collections.Generic;

namespace MetDashboard.Data.Models;

public partial class Openmaintenancerequest
{
    public int RequestId { get; set; }

    public string Address { get; set; } = null!;

    public string AssignedTo { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? RequestDate { get; set; }
}
