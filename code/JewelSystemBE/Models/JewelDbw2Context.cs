using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JewelSystemBE.Models;

public partial class JewelDbw2Context : DbContext
{
    public JewelDbw2Context()
    {
    }

    public JewelDbw2Context(DbContextOptions<JewelDbw2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Gem> Gems { get; set; }

    public virtual DbSet<Gold> Golds { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Stall> Stalls { get; set; }

    public virtual DbSet<StallEmployee> StallEmployees { get; set; }

    public virtual DbSet<StallItem> StallItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Warranty> Warranties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=JewelDBW2;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8B3BE52F1");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasMaxLength(255);
            entity.Property(e => e.CustomerName).HasMaxLength(255);
            entity.Property(e => e.CustomerPhone).HasMaxLength(255);
            entity.Property(e => e.CustomerRank).HasMaxLength(255);
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.DiscountId).HasName("PK__Discount__E43F6D9603E76541");

            entity.ToTable("Discount");

            entity.Property(e => e.DiscountId).HasMaxLength(255);
            entity.Property(e => e.DiscountName).HasMaxLength(255);
            entity.Property(e => e.DiscountRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.OrderType).HasMaxLength(255);
            entity.Property(e => e.ProductId).HasMaxLength(255);
            entity.Property(e => e.ProductType).HasMaxLength(255);

            entity.HasOne(d => d.Product).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Discount__Produc__49C3F6B7");
        });

        modelBuilder.Entity<Gem>(entity =>
        {
            entity.HasKey(e => e.GemId).HasName("PK__Gem__F101D58072F606CC");

            entity.ToTable("Gem");

            entity.Property(e => e.GemId).HasMaxLength(255);
            entity.Property(e => e.BuyPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GemCode).HasMaxLength(255);
            entity.Property(e => e.GemName).HasMaxLength(255);
            entity.Property(e => e.GemPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GemWeight).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Unit).HasMaxLength(255);
        });

        modelBuilder.Entity<Gold>(entity =>
        {
            entity.HasKey(e => e.GoldId).HasName("PK__Gold__5CD52C53A3F56433");

            entity.ToTable("Gold");

            entity.Property(e => e.GoldId).HasMaxLength(255);
            entity.Property(e => e.BuyPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GoldCode).HasMaxLength(255);
            entity.Property(e => e.GoldName).HasMaxLength(255);
            entity.Property(e => e.SellPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Unit).HasMaxLength(255);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoice__D796AAB5F77AD864");

            entity.ToTable("Invoice");

            entity.Property(e => e.InvoiceId).HasMaxLength(255);
            entity.Property(e => e.CashierFullname).HasMaxLength(255);
            entity.Property(e => e.CashierId).HasMaxLength(255);
            entity.Property(e => e.CustomerId).HasMaxLength(255);
            entity.Property(e => e.CustomerName).HasMaxLength(255);
            entity.Property(e => e.CustomerVoucher).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EndTotalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InvoiceStatus).HasMaxLength(255);
            entity.Property(e => e.InvoiceType).HasMaxLength(255);
            entity.Property(e => e.ManagerFullname).HasMaxLength(255);
            entity.Property(e => e.ManagerId).HasMaxLength(255);
            entity.Property(e => e.StallId).HasMaxLength(255);
            entity.Property(e => e.StallName).HasMaxLength(255);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UserFullname).HasMaxLength(255);
            entity.Property(e => e.UserId).HasMaxLength(255);

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Invoice__Custome__3B75D760");

            entity.HasOne(d => d.User).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Invoice__UserId__3C69FB99");
        });

        modelBuilder.Entity<InvoiceItem>(entity =>
        {
            entity.HasKey(e => e.InvoiceItemId).HasName("PK__InvoiceI__478FE09CB9956CF1");

            entity.ToTable("InvoiceItem");

            entity.Property(e => e.InvoiceItemId).HasMaxLength(255);
            entity.Property(e => e.DiscountId).HasMaxLength(255);
            entity.Property(e => e.DiscountRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.EndTotalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InvoiceId).HasMaxLength(255);
            entity.Property(e => e.ProductId).HasMaxLength(255);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.StallId).HasMaxLength(255);
            entity.Property(e => e.StallName).HasMaxLength(255);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.WarrantyId).HasMaxLength(255);

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK__InvoiceIt__Invoi__4E88ABD4");

            entity.HasOne(d => d.Warranty).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.WarrantyId)
                .HasConstraintName("FK__InvoiceIt__Warra__4F7CD00D");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CD426EF22F");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasMaxLength(255);
            entity.Property(e => e.BuyPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GemId).HasMaxLength(255);
            entity.Property(e => e.GemName).HasMaxLength(255);
            entity.Property(e => e.GemWeight).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GoldId).HasMaxLength(255);
            entity.Property(e => e.GoldName).HasMaxLength(255);
            entity.Property(e => e.GoldWeight).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LaborCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MarkupRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ProductCode).HasMaxLength(255);
            entity.Property(e => e.ProductImages).HasMaxLength(255);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.ProductType).HasMaxLength(255);
            entity.Property(e => e.ProductWeight).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Gem).WithMany(p => p.Products)
                .HasForeignKey(d => d.GemId)
                .HasConstraintName("FK__Product__GemId__45F365D3");

            entity.HasOne(d => d.Gold).WithMany(p => p.Products)
                .HasForeignKey(d => d.GoldId)
                .HasConstraintName("FK__Product__GoldId__46E78A0C");
        });

        modelBuilder.Entity<Stall>(entity =>
        {
            entity.HasKey(e => e.StallId).HasName("PK__Stall__A9EDB1A8EFA052AD");

            entity.ToTable("Stall");

            entity.Property(e => e.StallId).HasMaxLength(255);
            entity.Property(e => e.StaffName).HasMaxLength(255);
            entity.Property(e => e.StallDescription).HasMaxLength(255);
            entity.Property(e => e.StallName).HasMaxLength(255);
            entity.Property(e => e.StallType).HasMaxLength(255);
            entity.Property(e => e.UserId).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.Stalls)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Stall__UserId__3F466844");
        });

        modelBuilder.Entity<StallEmployee>(entity =>
        {
            entity.HasKey(e => e.StallEmployeeId).HasName("PK__StallEmp__A5C2F78AB1DFAC71");

            entity.ToTable("StallEmployee");

            entity.Property(e => e.StallEmployeeId).HasMaxLength(255);
            entity.Property(e => e.EmployeeFullname).HasMaxLength(255);
            entity.Property(e => e.EmployeeId).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.StallId).HasMaxLength(255);
            entity.Property(e => e.StallName).HasMaxLength(255);

            entity.HasOne(d => d.Employee).WithMany(p => p.StallEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__StallEmpl__Emplo__534D60F1");

            entity.HasOne(d => d.Stall).WithMany(p => p.StallEmployees)
                .HasForeignKey(d => d.StallId)
                .HasConstraintName("FK__StallEmpl__Stall__52593CB8");
        });

        modelBuilder.Entity<StallItem>(entity =>
        {
            entity.HasKey(e => e.StallItemId).HasName("PK__StallIte__F36E51DA80A217F5");

            entity.ToTable("StallItem");

            entity.Property(e => e.StallItemId).HasMaxLength(255);
            entity.Property(e => e.ProductId).HasMaxLength(255);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.StallId).HasMaxLength(255);

            entity.HasOne(d => d.Product).WithMany(p => p.StallItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__StallItem__Produ__571DF1D5");

            entity.HasOne(d => d.Stall).WithMany(p => p.StallItems)
                .HasForeignKey(d => d.StallId)
                .HasConstraintName("FK__StallItem__Stall__5629CD9C");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4CC065BDDD");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        modelBuilder.Entity<Warranty>(entity =>
        {
            entity.HasKey(e => e.WarrantyId).HasName("PK__Warranty__2ED3181375F96BA2");

            entity.ToTable("Warranty");

            entity.Property(e => e.WarrantyId).HasMaxLength(255);
            entity.Property(e => e.ProductId).HasMaxLength(255);
            entity.Property(e => e.ProductName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
