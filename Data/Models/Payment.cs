using System;
using System.Collections.Generic;

namespace MetDashboard.Data.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? LeaseId { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    public string? PaymentMethod { get; set; }

    public int? ReceivedBy { get; set; }

    public virtual Lease? Lease { get; set; }

    public virtual ICollection<Paymentaudit> Paymentaudits { get; set; } = new List<Paymentaudit>();

    public virtual Employee? ReceivedByNavigation { get; set; }
}
