using System;
using System.Collections.Generic;

namespace UnionMarket.Models.Entities;

public partial class Report
{
    public Guid Id { get; set; }

    public Guid? ReporterId { get; set; }

    public string? TargetType { get; set; }

    public Guid? TargetId { get; set; }

    public string? Reason { get; set; }

    public DateTime? CreatedAt { get; set; }
}
