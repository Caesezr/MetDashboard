using System;
using System.Collections.Generic;

namespace MetDashboard.Data.Models;

public partial class Propertyowner
{
    public int PropertyId { get; set; }

    public int OwnerId { get; set; }

    public decimal? OwnershipPercentage { get; set; }

    public virtual Owner Owner { get; set; } = null!;

    public virtual Property Property { get; set; } = null!;
}
