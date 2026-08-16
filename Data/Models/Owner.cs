using System;
using System.Collections.Generic;

namespace MetDashboard.Data.Models;

public partial class Owner
{
    public int OwnerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? MailingAddress { get; set; }

    public virtual ICollection<Propertyowner> Propertyowners { get; set; } = new List<Propertyowner>();
}
