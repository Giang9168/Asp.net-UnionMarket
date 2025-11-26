using System;
using System.Collections.Generic;

namespace UnionMarket.Models.Entities;

public partial class Product
{
    public Guid Id { get; set; }

    public Guid? ShopId { get; set; }

    public Guid? CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public decimal? SalePrice { get; set; }

    public int? Stock { get; set; }

    public int? SoldCount { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Shop? Shop { get; set; }

    public virtual ICollection<ProductTag> Tags { get; set; } = new List<ProductTag>();
}
