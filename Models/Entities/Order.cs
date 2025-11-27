using System;
using System.Collections.Generic;

namespace UnionMarket.Models.Entities;

public partial class Order
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public Guid? AddressId { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? Status { get; set; }

    public string? PaymentMethod { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual UserAddress? Address { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<OrderStatusHistory> OrderStatusHistories { get; set; } = new List<OrderStatusHistory>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    public virtual User? User { get; set; }
}
