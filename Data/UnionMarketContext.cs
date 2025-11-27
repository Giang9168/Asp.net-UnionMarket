using EFCore.NamingConventions; 
using EFCore.NamingConventions.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using UnionMarket.Models;
using UnionMarket.Models.Entities;

namespace UnionMarket.Data;



public partial class UnionMarketContext : DbContext
{
    public UnionMarketContext()
    {
    }

    public UnionMarketContext(DbContextOptions<UnionMarketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    
    public virtual DbSet<UserProfile> UserProfiles { get; set; }
    public virtual DbSet<UserAddress> UserAddresses { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }
    public virtual DbSet<ShopFollower> ShopFollowers { get; set; }
    // nếu có:
    public virtual DbSet<ShopReview> ShopReviews { get; set; }
     public virtual DbSet<ShopCategory> ShopCategories { get; set; } // nếu bạn tạo thêm

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductImage> ProductImages { get; set; }
    public virtual DbSet<ProductVariant> ProductVariants { get; set; }
    public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
    public virtual DbSet<ProductTag> ProductTags { get; set; }
    
    public virtual DbSet<ProductView> ProductViews { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }
    public virtual DbSet<CartItem> CartItems { get; set; }
    public virtual DbSet<CheckoutSession> CheckoutSessions { get; set; }

    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderItem> OrderItems { get; set; }
    public virtual DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }
    public virtual DbSet<ShippingCompany> ShippingCompanies { get; set; }
    // nếu có
    public virtual DbSet<ShipmentLog> ShipmentLogs { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }
    public virtual DbSet<WalletTransaction> WalletTransactions { get; set; }
    public virtual DbSet<SellerEarning> SellerEarnings { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }
    public virtual DbSet<UserVoucher> UserVouchers { get; set; }

    public virtual DbSet<Conversation> Conversations { get; set; }
    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }
    public virtual DbSet<AuditLog> AuditLogs { get; set; }
    public virtual DbSet<LoginHistory> LoginHistories { get; set; }
    public virtual DbSet<SearchHistory> SearchHistories { get; set; }

    public virtual DbSet<FlashSale> FlashSales { get; set; }
    public virtual DbSet<Report> Reports { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-7J5LOJP\\MSSQLSERVER01,1433;Database=UnionMarket;User Id=sa;Password=123456789;TrustServerCertificate=True;")
           .UseSnakeCaseNamingConvention();
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity<Dictionary<string, object>>(
                "user_roles", // <-- TÊN BẢNG TRUNG GIAN
                j => j.HasOne<Role>()
                      .WithMany()
                      .HasForeignKey("role_id")
                      .HasConstraintName("FK_user_roles_roles"),
                j => j.HasOne<User>()
                      .WithMany()
                      .HasForeignKey("user_id")
                      .HasConstraintName("FK_user_roles_users")
            );
        });

        modelBuilder.Entity<Role>().ToTable("roles");

        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
