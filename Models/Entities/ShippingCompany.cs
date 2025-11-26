using System;
using System.Collections.Generic;

namespace UnionMarket.Models;

public partial class ShippingCompany
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Logo { get; set; }

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
