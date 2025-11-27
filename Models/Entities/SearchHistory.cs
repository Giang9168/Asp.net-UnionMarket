using System;
using System.Collections.Generic;

namespace UnionMarket.Models;

public partial class SearchHistory
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? Keyword { get; set; }

    public DateTime? SearchedAt { get; set; }

    public virtual User? User { get; set; }
}
