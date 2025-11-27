using System;
using System.Collections.Generic;
using UnionMarket.Models.Entities;

namespace UnionMarket.Models;

public partial class Shipment
{
    public Guid Id { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? ShippingCompanyId { get; set; }

    public string? TrackingCode { get; set; }

    public string? Status { get; set; }

    public DateTime? ShippedAt { get; set; }

    public DateTime? DeliveredAt { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ICollection<ShipmentLog> ShipmentLogs { get; set; } = new List<ShipmentLog>();

    public virtual ShippingCompany? ShippingCompany { get; set; }
}
