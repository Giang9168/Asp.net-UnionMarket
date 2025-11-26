using System;
using System.Collections.Generic;

namespace UnionMarket.Models.Entities;

public partial class CheckoutSession
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public decimal? TotalProducts { get; set; }

    public decimal? TotalShipping { get; set; }

    public decimal? TotalDiscount { get; set; }

    public decimal? FinalAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
