using System;
using System.Collections.Generic;

namespace UnionMarket.Models.Entities;

public partial class ProductTag
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
