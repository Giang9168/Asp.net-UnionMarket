using System;
using System.Collections.Generic;

namespace UnionMarket.Models.Entities;

public partial class Category
{
    public Guid Id { get; set; }

    public Guid? ParentId { get; set; }

    public string? Name { get; set; }

    public string? Slug { get; set; }

    public string? Icon { get; set; }

    public virtual ICollection<Category> InverseParent { get; set; } = new List<Category>();

    public virtual Category? Parent { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
