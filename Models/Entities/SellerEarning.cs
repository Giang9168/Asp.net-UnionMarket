using System;
using System.Collections.Generic;
using UnionMarket.Models.Entities;

namespace UnionMarket.Models;

public partial class SellerEarning
{
    public Guid Id { get; set; }

    public Guid? ShopId { get; set; }

    public Guid? OrderItemId { get; set; }

    public decimal? Amount { get; set; }

    public string? Status { get; set; }

    public virtual OrderItem? OrderItem { get; set; }

    public virtual Shop? Shop { get; set; }
}
