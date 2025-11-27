using System;
using System.Collections.Generic;

namespace UnionMarket.Models.Entities;

public partial class ProductImage
{
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public string? ImageUrl { get; set; }

    public bool? IsMain { get; set; }

    public virtual Product? Product { get; set; }
}
