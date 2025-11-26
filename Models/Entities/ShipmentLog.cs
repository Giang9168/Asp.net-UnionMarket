using System;
using System.Collections.Generic;

namespace UnionMarket.Models;

public partial class ShipmentLog
{
    public Guid Id { get; set; }

    public Guid? ShipmentId { get; set; }

    public string? Location { get; set; }

    public string? Status { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Shipment? Shipment { get; set; }
}
