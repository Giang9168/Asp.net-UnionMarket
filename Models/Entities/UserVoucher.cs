using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnionMarket.Models;

[NotMapped]

public partial class UserVoucher
{
    public Guid UserId { get; set; }

    public Guid VoucherId { get; set; }

    public bool? IsUsed { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual Voucher Voucher { get; set; } = null!;
}
