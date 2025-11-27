using System;
using System.Collections.Generic;

namespace UnionMarket.Models;

public partial class Voucher
{
    public Guid Id { get; set; }

    public string? Code { get; set; }

    public decimal? DiscountValue { get; set; }

    public decimal? MinOrder { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? Quantity { get; set; }

    public virtual ICollection<UserVoucher> UserVouchers { get; set; } = new List<UserVoucher>();
}
