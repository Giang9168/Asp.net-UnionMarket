using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnionMarket.Models.Entities;

namespace UnionMarket.Models
{
    [Table("users", Schema = "dbo")]   // << map đúng tên bảng
    public partial class User
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }


        // GIỮ TÊN PasswordHash nhưng map về cột "password"
        [Column("password_hash")]
        public string PasswordHash { get; set; } = null!;

        [Column("status")]
        public string? Status { get; set; }


        // GIỮ TÊN nhưng map đúng cột snake_case
        [Column("email_verified_at")]
        public DateTime? EmailVerifiedAt { get; set; }

        [Column("phone_verified_at")]
        public DateTime? PhoneVerifiedAt { get; set; }

        [Column("last_login_at")]
        public DateTime? LastLoginAt { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }



        // ===== Navigation giữ nguyên của bạn =====

        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

        public virtual ICollection<CheckoutSession> CheckoutSessions { get; set; } = new List<CheckoutSession>();

        public virtual ICollection<Conversation> ConversationBuyers { get; set; } = new List<Conversation>();

        public virtual ICollection<Conversation> ConversationSellers { get; set; } = new List<Conversation>();

        public virtual ICollection<LoginHistory> LoginHistories { get; set; } = new List<LoginHistory>();

        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public virtual ICollection<SearchHistory> SearchHistories { get; set; } = new List<SearchHistory>();

        public virtual Shop? Shop { get; set; }

        public virtual ICollection<ShopFollower> ShopFollowers { get; set; } = new List<ShopFollower>();

        public virtual ICollection<ShopReview> ShopReviews { get; set; } = new List<ShopReview>();

        public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();

        public virtual UserProfile? UserProfile { get; set; }

        public virtual ICollection<UserVoucher> UserVouchers { get; set; } = new List<UserVoucher>();

        public virtual Wallet? Wallet { get; set; }

        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
