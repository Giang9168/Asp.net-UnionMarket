using System;
using System.Collections.Generic;
using UnionMarket.Models.Entities;

namespace UnionMarket.Models;

public partial class Shop
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? ShopName { get; set; }

    public string? Description { get; set; }

    public string? Logo { get; set; }

    public string? CoverImage { get; set; }

    public double? RatingAvg { get; set; }

    public int? FollowersCount { get; set; }

    public bool? IsVerified { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<SellerEarning> SellerEarnings { get; set; } = new List<SellerEarning>();

    public virtual ICollection<ShopCategory> ShopCategories { get; set; } = new List<ShopCategory>();

    public virtual ICollection<ShopFollower> ShopFollowers { get; set; } = new List<ShopFollower>();

    public virtual ICollection<ShopReview> ShopReviews { get; set; } = new List<ShopReview>();

    public virtual User? User { get; set; }
}
