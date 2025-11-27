using System;
using System.Collections.Generic;

namespace UnionMarket.Models.Entities;

public partial class OrderStatusHistory
{
    public Guid Id { get; set; }

    public Guid? OrderId { get; set; }

    public string? Status { get; set; }

    public DateTime? ChangedAt { get; set; }

    public string? Note { get; set; }

    public virtual Order? Order { get; set; }
}
