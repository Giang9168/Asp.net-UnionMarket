using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnionMarket.Models;

[NotMapped]

public partial class ShopFollower
{
    public Guid ShopId { get; set; }

    public Guid UserId { get; set; }

    public DateTime? FollowedAt { get; set; }

    public virtual Shop Shop { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
