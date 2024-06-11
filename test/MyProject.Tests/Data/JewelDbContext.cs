using JewelSystemBE.Model;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using MyProject.Tests.ServiceGold;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MyProject.Tests.Data
{
    public class JewelDbContext : DbContext
    {
        public JewelDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Jewel> Jewels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Gem> Gems { get; set; }
        public DbSet<Gold> Golds { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new JewelConfiguration());

            //modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("user");
                builder.HasKey(x => x.UserId);
                builder.Property(x => x.Username).IsRequired();
                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Fullname).IsRequired();
                builder.Property(x => x.Email).IsRequired();
                builder.Property(x => x.Role).IsRequired();

                // Seed data for User
                builder.HasData(
                    new User { UserId = "1", Username = "user1", Password = BCrypt.Net.BCrypt.HashPassword("password1"), Fullname = "User One", Email = "user1@example.com", Role = "Admin" },
                    new User { UserId = "2", Username = "user2", Password = BCrypt.Net.BCrypt.HashPassword("password2"), Fullname = "User Two", Email = "user2@example.com", Role = "User" },
                    new User { UserId = "3", Username = "user3", Password = BCrypt.Net.BCrypt.HashPassword("password3"), Fullname = "User Three", Email = "user3@example.com", Role = "User" },
                    new User { UserId = "4", Username = "user4", Password = BCrypt.Net.BCrypt.HashPassword("password4"), Fullname = "User Four", Email = "user4@example.com", Role = "User" },
                    new User { UserId = "5", Username = "user5", Password = BCrypt.Net.BCrypt.HashPassword("password5"), Fullname = "User Five", Email = "user5@example.com", Role = "User" }
                );
            });

            // Configure Jewel entity
            modelBuilder.Entity<Jewel>(builder =>
            {
                builder.ToTable("jewel");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).IsRequired();
                builder.Property(x => x.IsComplete).IsRequired().HasDefaultValue(false);

                // Seed data for Jewel
                builder.HasData(
                    new Jewel { Id = 1, Name = "Necklace", IsComplete = false },
                    new Jewel { Id = 2, Name = "Bracelet", IsComplete = false },
                    new Jewel { Id = 3, Name = "Ring", IsComplete = false },
                    new Jewel { Id = 4, Name = "Earrings", IsComplete = false },
                    new Jewel { Id = 5, Name = "Pendant", IsComplete = false }
                );
            });

            modelBuilder.Entity<Gem>(entity =>
            {
                entity.ToTable("gem");
                entity.HasKey(e => e.GemId);
                entity.Property(e => e.GemId).HasColumnName("gem_id");
                entity.Property(e => e.GemName).HasColumnName("gem_name");
                entity.Property(e => e.GemPrice).HasColumnName("gem_price").HasColumnType("decimal(10, 2)");

                entity.HasData(
                    new Gem { GemId = "1", GemName = "Ruby", GemPrice = 1000.00m },
                    new Gem { GemId = "2", GemName = "Sapphire", GemPrice = 1500.00m },
                    new Gem { GemId = "3", GemName = "Emerald", GemPrice = 1200.00m },
                    new Gem { GemId = "4", GemName = "Diamond", GemPrice = 5000.00m },
                    new Gem { GemId = "5", GemName = "Topaz", GemPrice = 800.00m }
                );
            });
            modelBuilder.Entity<Gold>(entity =>
            {
                entity.ToTable("gold");
                entity.HasKey(e => e.GoldId);
                entity.Property(e => e.GoldId).HasColumnName("gold_id");
                entity.Property(e => e.GoldName).HasColumnName("gold_name");
                entity.Property(e => e.GoldPrice).HasColumnName("gold_price").HasColumnType("decimal(10, 2)");

                entity.HasData(
                    new Gold { GoldId = "1", GoldName = "24K Gold", GoldPrice = 6000.00m },
                    new Gold { GoldId = "2", GoldName = "22K Gold", GoldPrice = 5500.00m },
                    new Gold { GoldId = "3", GoldName = "18K Gold", GoldPrice = 4500.00m },
                    new Gold { GoldId = "4", GoldName = "14K Gold", GoldPrice = 4000.00m },
                    new Gold { GoldId = "5", GoldName = "10K Gold", GoldPrice = 3500.00m }
                );
            });

            //config the Product entity with sql server begins here
            modelBuilder.Entity<Product>(entity =>
            {
                //mapping the properties begins here
                entity.ToTable("product");
                entity.HasKey(e => e.ProductId);
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductCode).HasColumnName("product_code").IsRequired().HasMaxLength(50);
                entity.Property(e => e.ProductName).HasColumnName("product_name").IsRequired().HasMaxLength(100);
                entity.Property(e => e.ProductImages).HasColumnName("product_images").IsRequired().HasMaxLength(200);
                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity").IsRequired();
                entity.Property(e => e.ProductType).HasColumnName("product_type").IsRequired().HasMaxLength(100);
                entity.Property(e => e.ProductWeight).HasColumnName("product_weight").IsRequired();
                entity.Property(e => e.ProductWarranty).HasColumnName("product_warranty").IsRequired();
                entity.Property(e => e.MarkupRate).HasColumnName("markup_rate").IsRequired();
                entity.Property(e => e.GemId).HasColumnName("gem_id").IsRequired();
                entity.Property(e => e.GemWeight).HasColumnName("gem_weight").IsRequired();
                entity.Property(e => e.GoldId).HasColumnName("gold_id").IsRequired();
                entity.Property(e => e.GoldWeight).HasColumnName("gold_weight").IsRequired();
                entity.Property(e => e.LaborCost).HasColumnName("labor_cost").HasColumnType("decimal(10, 2)").HasDefaultValue(0);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("GETDATE()");
                //mapping the proterties ends here

                //checking values of some properties begins here
                entity.HasCheckConstraint("CK_Products_ProductQuantity", "product_quantity > 0");
                entity.HasCheckConstraint("CK_Products_ProductWeight", "product_weight > 0");
                entity.HasCheckConstraint("CK_Products_GemWeight", "gem_weight > 0");
                entity.HasCheckConstraint("CK_Products_GoldWeight", "gold_weight > 0");
                entity.HasCheckConstraint("CK_Products_LaborCost", "labor_cost >= 0");
                //checking values of some properties ends here

                //linking the relationship begins here
                entity.HasOne(p => p.Gem)
                .WithOne()
                .HasForeignKey<Product>(p => p.GemId);

                entity.HasOne(p => p.Gold)
                    .WithMany()
                    .HasForeignKey(p => p.GoldId);
                //linking the relationship ends here

                //seeding data begins here
                entity.HasData(
                new Product
                {
                    ProductId = Guid.NewGuid().ToString(),
                    ProductCode = "P001",
                    ProductName = "Ruby Necklace",
                    ProductImages = "ruby_necklace.jpg",
                    ProductQuantity = 10,
                    ProductType = "Necklace",
                    ProductWeight = 50.0,
                    ProductWarranty = 12,
                    MarkupRate = 1.2f,
                    GemId = "1",
                    GemWeight = 5.0,
                    GoldId = "1",
                    GoldWeight = 45.0,
                    LaborCost = 200.00m,
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    ProductId = Guid.NewGuid().ToString(),
                    ProductCode = "P002",
                    ProductName = "Sapphire Ring",
                    ProductImages = "sapphire_ring.jpg",
                    ProductQuantity = 5,
                    ProductType = "Ring",
                    ProductWeight = 20.0,
                    ProductWarranty = 24,
                    MarkupRate = 1.5f,
                    GemId = "2",
                    GemWeight = 2.0,
                    GoldId = "2",
                    GoldWeight = 18.0,
                    LaborCost = 100.00m,
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    ProductId = Guid.NewGuid().ToString(),
                    ProductCode = "P003",
                    ProductName = "Emerald Bracelet",
                    ProductImages = "emerald_bracelet.jpg",
                    ProductQuantity = 8,
                    ProductType = "Bracelet",
                    ProductWeight = 30.0,
                    ProductWarranty = 18,
                    MarkupRate = 1.3f,
                    GemId = "3",
                    GemWeight = 3.0,
                    GoldId = "3",
                    GoldWeight = 27.0,
                    LaborCost = 150.00m,
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    ProductId = Guid.NewGuid().ToString(),
                    ProductCode = "P004",
                    ProductName = "Diamond Earrings",
                    ProductImages = "diamond_earrings.jpg",
                    ProductQuantity = 12,
                    ProductType = "Earrings",
                    ProductWeight = 15.0,
                    ProductWarranty = 24,
                    MarkupRate = 1.7f,
                    GemId = "4",
                    GemWeight = 1.5,
                    GoldId = "4",
                    GoldWeight = 13.5,
                    LaborCost = 180.00m,
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    ProductId = Guid.NewGuid().ToString(),
                    ProductCode = "P005",
                    ProductName = "Topaz Pendant",
                    ProductImages = "topaz_pendant.jpg",
                    ProductQuantity = 20,
                    ProductType = "Pendant",
                    ProductWeight = 10.0,
                    ProductWarranty = 6,
                    MarkupRate = 1.1f,
                    GemId = "5",
                    GemWeight = 2.5,
                    GoldId = "5",
                    GoldWeight = 7.5,
                    LaborCost = 90.00m,
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    ProductId = Guid.NewGuid().ToString(),
                    ProductCode = "P006",
                    ProductName = "Ruby Bracelet",
                    ProductImages = "ruby_bracelet.jpg",
                    ProductQuantity = 7,
                    ProductType = "Bracelet",
                    ProductWeight = 25.0,
                    ProductWarranty = 12,
                    MarkupRate = 1.2f,
                    GemId = "1",
                    GemWeight = 4.0,
                    GoldId = "2",
                    GoldWeight = 21.0,
                    LaborCost = 130.00m,
                    CreatedAt = DateTime.Now
                }); // seeding data ends here

                entity.HasIndex(e => e.GemId).IsUnique(false);
                entity.HasIndex(e => e.GoldId).IsUnique(false);
            });
            //config the Product entity with sql server ends here

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("discount");

                entity.HasKey(e => e.DiscountId);

                entity.Property(e => e.DiscountId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DiscountName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.OrderType)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ProductType)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PublicDate)
                    .IsRequired();

                entity.Property(e => e.ExpireDate)
                    .IsRequired();


                // Seed sample data for Discounts
                entity.HasData(
                    new Discount
                    {
                        DiscountId = "1",
                        DiscountName = "Summer Sale",
                        OrderType = "Sale",
                        ProductType = "Jewelry 1",
                        PublicDate = new DateTime(2024, 6, 1),
                        ExpireDate = new DateTime(2024, 6, 30)
                    },
                    new Discount
                    {
                        DiscountId = "2",
                        DiscountName = "Holiday Promotion",
                        OrderType = "Sale",
                        ProductType = "Jewelry 2",
                        PublicDate = new DateTime(2024, 11, 15),
                        ExpireDate = new DateTime(2024, 12, 31)
                    },
                    new Discount
                    {
                        DiscountId = "3",
                        DiscountName = "Spring Clearance",
                        OrderType = "Buyback",
                        ProductType = "Jewelry 3",
                        PublicDate = new DateTime(2024, 3, 1),
                        ExpireDate = new DateTime(2024, 3, 31)
                    },
                    new Discount
                    {
                        DiscountId = "4",
                        DiscountName = "Back-to-School Sale",
                        OrderType = "Sale",
                        ProductType = "Jewelry 4",
                        PublicDate = new DateTime(2024, 8, 1),
                        ExpireDate = new DateTime(2024, 9, 15)
                    },
                    new Discount
                    {
                        DiscountId = "5",
                        DiscountName = "Winter Warm-up",
                        OrderType = "Buyback",
                        ProductType = "Jewelry 5",
                        PublicDate = new DateTime(2024, 12, 1),
                        ExpireDate = new DateTime(2025, 1, 31)
                    }

                    );
            });

        }


    }
}
