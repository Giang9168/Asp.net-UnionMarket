using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnionMarket.Models.Entities;



public partial class Conversation
{
    public Guid Id { get; set; }

    public Guid? BuyerId { get; set; }

    public Guid? SellerId { get; set; }

    public DateTime? CreatedAt { get; set; }

    [NotMapped]
    public virtual User? Buyer { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    [NotMapped]
    public virtual User? Seller { get; set; }
}
