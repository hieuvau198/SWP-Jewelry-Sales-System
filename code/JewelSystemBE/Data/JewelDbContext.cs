using JewelSystemBE.Model;
using Microsoft.EntityFrameworkCore;

namespace JewelSystemBE.Data
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
        public DbSet<Warranty> Warranties { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }


        public DbSet<ImageRecord> ImageRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new JewelConfiguration());

            //modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<ImageRecord>(builder =>
            {
                builder.HasData(
                    new ImageRecord {Id = "2f29b6a7-8010-4a90-853f-c896fd387793", FileName = "dfyqz4e-f004994b-129e-44ad-853f-3eaae3112671.jpg", Path = "dfyqz4e-f004994b-129e-44ad-853f-3eaae3112671.jpg" },
                    new ImageRecord {Id = "58bbac95-17ef-484c-a0d8-24494f8d36a5", FileName = "hentai.png", Path = "hentai.png" },
                    new ImageRecord {Id = "de9b5453-15d2-41a0-922e-1edbcc6e0bef", FileName = "maxresdefault.jpg", Path = "maxresdefault.jpg" },
                    new ImageRecord {Id = "e4b1110f-0340-48d3-82b0-9315acc175e0", FileName = "RDT_20240603_1700187451959011441817016.jpg", Path = "RDT_20240603_1700187451959011441817016.jpg" }
                    );
            });

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
            modelBuilder.Entity<Warranty>(entity =>
            {
                entity.ToTable("warranty");
                entity.HasKey(e => e.WarrantyId);
                entity.Property(e => e.WarrantyId).HasColumnName("warranty_id").IsRequired();
                entity.Property(e => e.ProductId).HasColumnName("product_id").IsRequired();
                entity.Property(e => e.ProductName).HasColumnName("product_name").IsRequired();
                entity.Property(e => e.StartDate).HasColumnName("start_date").IsRequired().HasColumnType("date");
                entity.Property(e => e.ExpireDate).HasColumnName("expire_date").IsRequired().HasColumnType("date");

                entity.HasData(
                    new Warranty { WarrantyId = "W1", ProductId = "P1", ProductName = "Product A", StartDate = new DateTime(2023, 1, 1), ExpireDate = new DateTime(2024, 1, 1) },
                    new Warranty { WarrantyId = "W2", ProductId = "P2", ProductName = "Product B", StartDate = new DateTime(2023, 2, 1), ExpireDate = new DateTime(2024, 2, 1) },
                    new Warranty { WarrantyId = "W3", ProductId = "P3", ProductName = "Product C", StartDate = new DateTime(2023, 3, 1), ExpireDate = new DateTime(2024, 3, 1) }
                );
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");
                entity.HasKey(e => e.CustomerId);
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.CustomerName).HasColumnName("customer_name").IsRequired();
                entity.Property(e => e.CustomerRank).HasColumnName("customer_rank").IsRequired();
                entity.Property(e => e.CustomerPoint).HasColumnName("customer_point").IsRequired();
                entity.Property(e => e.AttendDate).HasColumnName("attend_date").IsRequired().HasColumnType("date");

                entity.HasData(
                    new Customer { CustomerId = "C1", CustomerName = "John Doe", CustomerRank = "Gold", CustomerPoint = 100, AttendDate = new DateTime(2024, 1, 15) },
                    new Customer { CustomerId = "C2", CustomerName = "Jane Smith", CustomerRank = "Silver", CustomerPoint = 80, AttendDate = new DateTime(2024, 2, 20) },
                    new Customer { CustomerId = "C3", CustomerName = "Alice Johnson", CustomerRank = "Bronze", CustomerPoint = 50, AttendDate = new DateTime(2024, 3, 25) },
                    new Customer { CustomerId = "C4", CustomerName = "Bob Brown", CustomerRank = "Bronze", CustomerPoint = 120, AttendDate = new DateTime(2024, 4, 30) },
                    new Customer { CustomerId = "C5", CustomerName = "Emily Wilson", CustomerRank = "Bronze", CustomerPoint = 90, AttendDate = new DateTime(2024, 5, 5) }
                );
            });
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoice");
                entity.HasKey(e => e.InvoiceId);
                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
                entity.Property(e => e.InvoiceType).HasColumnName("invoice_type").IsRequired();
                entity.Property(e => e.CustomerId).HasColumnName("customer_id").IsRequired();
                entity.Property(e => e.UserId).HasColumnName("user_id").IsRequired();
                entity.Property(e => e.InvoiceDate).HasColumnName("invoice_date").HasColumnType("date").IsRequired();
                entity.Property(e => e.CustomerVoucher).HasColumnName("customer_voucher").HasColumnType("decimal(18, 2)").IsRequired();
                entity.Property(e => e.TotalPrice).HasColumnName("total_price").HasColumnType("decimal(18, 2)").IsRequired();
                entity.Property(e => e.EndTotalPrice).HasColumnName("end_total_price").HasColumnType("decimal(18, 2)").IsRequired();

                entity.HasData(
                    new Invoice { InvoiceId = "I1", InvoiceType = "Type A", CustomerId = "C1", UserId = "U1", InvoiceDate = new DateTime(2024, 6, 1), CustomerVoucher = 50.00m, TotalPrice = 500.00m, EndTotalPrice = 450.00m },
                    new Invoice { InvoiceId = "I2", InvoiceType = "Type B", CustomerId = "C2", UserId = "U2", InvoiceDate = new DateTime(2024, 6, 2), CustomerVoucher = 30.00m, TotalPrice = 700.00m, EndTotalPrice = 670.00m },
                    new Invoice { InvoiceId = "I3", InvoiceType = "Type C", CustomerId = "C3", UserId = "U3", InvoiceDate = new DateTime(2024, 6, 3), CustomerVoucher = 20.00m, TotalPrice = 300.00m, EndTotalPrice = 280.00m },
                    new Invoice { InvoiceId = "I4", InvoiceType = "Type D", CustomerId = "C4", UserId = "U1", InvoiceDate = new DateTime(2024, 6, 4), CustomerVoucher = 40.00m, TotalPrice = 1000.00m, EndTotalPrice = 960.00m },
                    new Invoice { InvoiceId = "I5", InvoiceType = "Type E", CustomerId = "C5", UserId = "U2", InvoiceDate = new DateTime(2024, 6, 5), CustomerVoucher = 60.00m, TotalPrice = 800.00m, EndTotalPrice = 740.00m }
                );
            });
            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                // Mapping the table
                entity.ToTable("invoice_item");

                // Mapping the properties
                entity.HasKey(e => e.InvoiceItemId);
                entity.Property(e => e.InvoiceItemId).HasColumnName("invoice_item_id");
                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id").IsRequired();
                entity.Property(e => e.ProductName).HasColumnName("product_name").IsRequired().HasMaxLength(100);
                entity.Property(e => e.Quantity).HasColumnName("quantity").IsRequired();
                entity.Property(e => e.UnitPrice).HasColumnName("unit_price").IsRequired().HasColumnType("decimal(18, 2)");
                entity.Property(e => e.DiscountId).HasColumnName("discount_id");
                entity.Property(e => e.DiscountRate).HasColumnName("discount_rate").HasColumnType("decimal(5, 2)");
                entity.Property(e => e.TotalPrice).HasColumnName("total_price").IsRequired().HasColumnType("decimal(18, 2)");
                entity.Property(e => e.EndTotalPrice).HasColumnName("end_total_price").IsRequired().HasColumnType("decimal(18, 2)");
                entity.Property(e => e.WarrantyId).HasColumnName("warranty_id");

                // Adding check constraints
                entity.HasCheckConstraint("CK_InvoiceItem_Quantity", "quantity > 0");
                entity.HasCheckConstraint("CK_InvoiceItem_UnitPrice", "unit_price >= 0");
                entity.HasCheckConstraint("CK_InvoiceItem_TotalPrice", "total_price >= 0");
                entity.HasCheckConstraint("CK_InvoiceItem_EndTotalPrice", "end_total_price >= 0");

                // Mapping the relationships
                entity.HasOne(e => e.Invoice)
                    .WithMany()
                    .HasForeignKey(e => e.InvoiceId);

                entity.HasOne(e => e.Warranty)
                    .WithMany()
                    .HasForeignKey(e => e.WarrantyId);
                entity.HasIndex(e => e.InvoiceId).IsUnique(false);
                entity.HasIndex(e => e.WarrantyId).IsUnique(false);

                entity.HasData(
                    new InvoiceItem
                    {
                        InvoiceItemId = "1",
                        InvoiceId = "I1", // Assuming this matches an existing InvoiceId
                        ProductName = "Product 1",
                        Quantity = 2,
                        UnitPrice = 10.50m,
                        DiscountId = "1", // Assuming this is a string, provide a valid DiscountId if it exists
                        DiscountRate = 0,
                        TotalPrice = 21.00m,
                        EndTotalPrice = 21.00m,
                        WarrantyId = "W1", // Assuming this matches an existing WarrantyId
                        Invoice = null, // Assign null to navigation properties
                        Warranty = null
                    },
                    new InvoiceItem
                    {
                        InvoiceItemId = "2",
                        InvoiceId = "I1", // Assuming this matches an existing InvoiceId
                        ProductName = "Product 2",
                        Quantity = 1,
                        UnitPrice = 25.75m,
                        DiscountId = "1", // Assuming this is a string, provide a valid DiscountId if it exists
                        DiscountRate = 0.15m,
                        TotalPrice = 21.89m,
                        EndTotalPrice = 21.89m,
                        WarrantyId = "W2", // Assuming this is a string, provide a valid WarrantyId if it exists
                        Invoice = null, // Assign null to navigation properties
                        Warranty = null
                    }
                    );
            });




        }
    }
}
