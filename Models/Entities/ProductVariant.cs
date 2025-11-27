using System;
using System.Collections.Generic;

namespace UnionMarket.Models.Entities;

public partial class ProductVariant
{
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public string? VariantName { get; set; }

    public string? Sku { get; set; }

    public decimal? Price { get; set; }

    public int? Stock { get; set; }

    public virtual Product? Product { get; set; }
}
