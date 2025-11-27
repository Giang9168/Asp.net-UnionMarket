using System;
using System.Collections.Generic;

namespace UnionMarket.Models;

public partial class ShopReview
{
    public Guid Id { get; set; }

    public Guid? ShopId { get; set; }

    public Guid? UserId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Shop? Shop { get; set; }

    public virtual User? User { get; set; }
}
