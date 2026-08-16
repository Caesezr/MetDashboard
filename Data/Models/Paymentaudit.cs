using System;
using System.Collections.Generic;

namespace MetDashboard.Data.Models;

public partial class Paymentaudit
{
    public int AuditId { get; set; }

    public int? PaymentId { get; set; }

    public decimal? LateFee { get; set; }

    public DateTime? AuditTimestamp { get; set; }

    public virtual Payment? Payment { get; set; }
}
