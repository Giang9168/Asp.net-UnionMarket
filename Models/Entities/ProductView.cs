using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnionMarket.Models.Entities;

[NotMapped]

public partial class ProductView
{
    public Guid? UserId { get; set; }

    public Guid? ProductId { get; set; }

    public DateTime? ViewedAt { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
