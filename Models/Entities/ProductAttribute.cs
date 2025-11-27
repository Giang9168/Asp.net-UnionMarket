using System;
using System.Collections.Generic;

namespace UnionMarket.Models.Entities;

public partial class ProductAttribute
{
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public string? AttributeName { get; set; }

    public string? Value { get; set; }

    public virtual Product? Product { get; set; }
}
