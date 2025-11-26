using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnionMarket.Models;
[NotMapped]

public partial class UserProfile
{
    public Guid UserId { get; set; }

    public string? FullName { get; set; }

    public string? Avatar { get; set; }

    public string? Gender { get; set; }

    public DateOnly? Birthday { get; set; }

    public string? Bio { get; set; }

    public virtual User User { get; set; } = null!;
}
