using System;
using System.Collections.Generic;

namespace UnionMarket.Models.Entities;

public partial class LoginHistory
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? IpAddress { get; set; }

    public string? Device { get; set; }

    public DateTime? LoginTime { get; set; }

    public virtual User? User { get; set; }
}
