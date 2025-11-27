using System;
using System.Collections.Generic;

namespace UnionMarket.Models.Entities;

public partial class AuditLog
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? Action { get; set; }

    public string? TableName { get; set; }

    public Guid? RowId { get; set; }

    public DateTime? CreatedAt { get; set; }
}
