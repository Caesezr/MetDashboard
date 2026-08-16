using System;
using System.Collections.Generic;

namespace MetDashboard.Data.Models;

public partial class Property
{
    public int PropertyId { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string? PropertyType { get; set; }

    public int? SquareFeet { get; set; }

    public int? YearBuilt { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public decimal? PurchasePrice { get; set; }

    public virtual ICollection<Lease> Leases { get; set; } = new List<Lease>();

    public virtual ICollection<Maintenancerequest> Maintenancerequests { get; set; } = new List<Maintenancerequest>();

    public virtual ICollection<Propertyowner> Propertyowners { get; set; } = new List<Propertyowner>();
}
