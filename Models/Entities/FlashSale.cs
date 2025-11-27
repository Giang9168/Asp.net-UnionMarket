using System;
using System.Collections.Generic;

namespace UnionMarket.Models.Entities;

public partial class FlashSale
{
    public Guid Id { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }
}
