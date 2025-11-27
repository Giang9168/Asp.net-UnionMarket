using System;
using System.Collections.Generic;

namespace UnionMarket.Models;

public partial class WalletTransaction
{
    public Guid Id { get; set; }

    public Guid? WalletId { get; set; }

    public decimal? Amount { get; set; }

    public string? Type { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Wallet? Wallet { get; set; }
}
