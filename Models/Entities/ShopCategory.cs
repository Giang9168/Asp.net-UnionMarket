using System;
using System.Collections.Generic;

namespace UnionMarket.Models;

public partial class ShopCategory
{
    public Guid Id { get; set; }

    public Guid? ShopId { get; set; }

    public string? Name { get; set; }

    public virtual Shop? Shop { get; set; }
}
