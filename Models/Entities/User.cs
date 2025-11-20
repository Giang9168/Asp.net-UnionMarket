using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnionMarket.Models.Entities;

public partial class User
{
    public int Id { get; set; }

    [Required]
    public string Username { get; set; } = string.Empty;

    public string? Password { get; set; }= string.Empty;

    public int Role { get; set; }
}
