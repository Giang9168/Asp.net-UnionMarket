using System;
using System.Collections.Generic;

namespace UnionMarket.Models.Entities;

public partial class OrderItem
{
    public Guid Id { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? ShopId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<SellerEarning> SellerEarnings { get; set; } = new List<SellerEarning>();

    public virtual Shop? Shop { get; set; }
}
