using System;
using System.Collections.Generic;
using UnionMarket.Models.Entities;

namespace UnionMarket.Models;

public partial class UserAddress
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? ReceiverName { get; set; }

    public string? Phone { get; set; }

    public string? Province { get; set; }

    public string? District { get; set; }

    public string? Ward { get; set; }

    public string? Street { get; set; }

    public bool? IsDefault { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User? User { get; set; }
}
