using System;
using System.Collections.Generic;
using UnionMarket.Models.Entities;

namespace UnionMarket.Models;

public partial class Review
{
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? UserId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
