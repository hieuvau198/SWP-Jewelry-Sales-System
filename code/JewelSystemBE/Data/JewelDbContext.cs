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
        public DbSet<Stall> Stalls { get; set; }
        public DbSet<StallItem> StallItems { get; set; }

        public DbSet<ImageRecord> ImageRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ImageRecord>(builder =>
            {
                builder.HasData(
                    new ImageRecord { Id = "2f29b6a7-8010-4a90-853f-c896fd387793", FileName = "dfyqz4e-f004994b-129e-44ad-853f-3eaae3112671.jpg", Path = "dfyqz4e-f004994b-129e-44ad-853f-3eaae3112671.jpg" },
                    new ImageRecord { Id = "58bbac95-17ef-484c-a0d8-24494f8d36a5", FileName = "hentai.png", Path = "hentai.png" },
                    new ImageRecord { Id = "de9b5453-15d2-41a0-922e-1edbcc6e0bef", FileName = "maxresdefault.jpg", Path = "maxresdefault.jpg" },
                    new ImageRecord { Id = "e4b1110f-0340-48d3-82b0-9315acc175e0", FileName = "RDT_20240603_1700187451959011441817016.jpg", Path = "RDT_20240603_1700187451959011441817016.jpg" }
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
                    new User { UserId = "US1", Username = "user1", Password = BCrypt.Net.BCrypt.HashPassword("password1"), Fullname = "Liam Williams", Email = "liam@gmail.com", Role = "Admin" },
                    new User { UserId = "US2", Username = "user2", Password = BCrypt.Net.BCrypt.HashPassword("password2"), Fullname = "Olivia Miller", Email = "olivia@gmail.com", Role = "Manager" },
                    new User { UserId = "US3", Username = "user3", Password = BCrypt.Net.BCrypt.HashPassword("password3"), Fullname = "James Martinez", Email = "james@gmail.com", Role = "Sale" },
                    new User { UserId = "US4", Username = "user4", Password = BCrypt.Net.BCrypt.HashPassword("password4"), Fullname = "Mateo Martinez", Email = "matao@gmail.com", Role = "Sale" },
                    new User { UserId = "US5", Username = "user5", Password = BCrypt.Net.BCrypt.HashPassword("password5"), Fullname = "Theodore Garcia", Email = "theodore@gmail.com", Role = "Cashier" },
                    new User { UserId = "US6", Username = "user6", Password = BCrypt.Net.BCrypt.HashPassword("password6"), Fullname = "Isabel Rodriguez", Email = "isabel@gmail.com", Role = "Sale" },
                    new User { UserId = "US7", Username = "user7", Password = BCrypt.Net.BCrypt.HashPassword("password7"), Fullname = "Luna Taylor", Email = "luna@gmail.com", Role = "Sale" },
                    new User { UserId = "US8", Username = "user8", Password = BCrypt.Net.BCrypt.HashPassword("password8"), Fullname = "Emma Young", Email = "emma@gmail.com", Role = "Sale" }
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
                entity.Property(e => e.GemPrice).HasColumnName("gem_price");

                entity.HasData(

                    //10 Rubies
                        new Gem
                        {
                            GemId = "GE001",
                            GemCode = "JSG-R1",
                            GemName = "Natural Mozambique Ruby",
                            GemWeight = 0.98,
                            BuyPrice = 50000000,
                            GemPrice = 58000000
                        },
                        new Gem
                        {
                            GemId = "GE002",
                            GemCode = "JSG-R2",
                            GemName = "Burmese Ruby",
                            GemWeight = 28,
                            BuyPrice = 170000000,
                            GemPrice = 190000000
                        },
                        new Gem
                        {
                            GemId = "GE003",
                            GemCode = "JSG-R3",
                            GemName = "Thai Ruby",
                            GemWeight = 9.94,
                            BuyPrice = 8235000,
                            GemPrice = 9756000
                        },
                        new Gem
                        {
                            GemId = "GE004",
                            GemCode = "JSG-R4",
                            GemName = "India Ruby",
                            GemWeight = 5.91,
                            BuyPrice = 1322012,
                            GemPrice = 1709078
                        },
                        new Gem
                        {
                            GemId = "GE005",
                            GemCode = "JSG-R5",
                            GemName = "Mozambique Ruby",
                            GemWeight = 0.33,
                            BuyPrice = 6900000,
                            GemPrice = 7859078
                        },
                        new Gem
                        {
                            GemId = "GE006",
                            GemCode = "JSG-R6",
                            GemName = "Heated Natural Ruby",
                            GemWeight = 0.34,
                            BuyPrice = 3700000,
                            GemPrice = 4166666
                        },
                        new Gem
                        {
                            GemId = "GE007",
                            GemCode = "JSG-R7",
                            GemName = "Mozambique Ruby",
                            GemWeight = 0.36,
                            BuyPrice = 8989000,
                            GemPrice = 9789973
                        },
                        new Gem
                        {
                            GemId = "GE008",
                            GemCode = "JSG-R8",
                            GemName = "Mozambique Ruby (Heated)",
                            GemWeight = 0.49,
                            BuyPrice = 4950000,
                            GemPrice = 5826558
                        },
                        new Gem
                        {
                            GemId = "GE009",
                            GemCode = "JSG-R9",
                            GemName = "Mozambique Ruby",
                            GemWeight = 0.49,
                            BuyPrice = 11900000,
                            GemPrice = 13000000
                        },
                        new Gem
                        {
                            GemId = "GE010",
                            GemCode = "JSG-R10",
                            GemName = "Burma Ruby",
                            GemWeight = 0.54,
                            BuyPrice = 3000000,
                            GemPrice = 3658000
                        },
                    //10 Sapphires
                        new Gem
                        {
                            GemId = "GE011",
                            GemCode = "JSG-S1",
                            GemName = "Natural Ceylon Sapphire",
                            GemWeight = 1.02,
                            BuyPrice = 30000000,
                            GemPrice = 35000000
                        },
                        new Gem
                        {
                            GemId = "GE012",
                            GemCode = "JSG-S2",
                            GemName = "Burmese Sapphire",
                            GemWeight = 2.75,
                            BuyPrice = 65000000,
                            GemPrice = 75000000
                        },
                        new Gem
                        {
                            GemId = "GE013",
                            GemCode = "JSG-S3",
                            GemName = "Madagascar Sapphire",
                            GemWeight = 1.5,
                            BuyPrice = 22000000,
                            GemPrice = 26000000
                        },
                        new Gem
                        {
                            GemId = "GE014",
                            GemCode = "JSG-S4",
                            GemName = "Australian Sapphire",
                            GemWeight = 3.2,
                            BuyPrice = 18000000,
                            GemPrice = 21000000
                        },
                        new Gem
                        {
                            GemId = "GE015",
                            GemCode = "JSG-S5",
                            GemName = "Kashmir Sapphire",
                            GemWeight = 0.95,
                            BuyPrice = 120000000,
                            GemPrice = 140000000
                        },
                        new Gem
                        {
                            GemId = "GE016",
                            GemCode = "JSG-S6",
                            GemName = "Heated Natural Sapphire",
                            GemWeight = 2.1,
                            BuyPrice = 45000000,
                            GemPrice = 50000000
                        },
                        new Gem
                        {
                            GemId = "GE017",
                            GemCode = "JSG-S7",
                            GemName = "Thai Sapphire",
                            GemWeight = 1.8,
                            BuyPrice = 35000000,
                            GemPrice = 40000000
                        },
                        new Gem
                        {
                            GemId = "GE018",
                            GemCode = "JSG-S8",
                            GemName = "Montana Sapphire",
                            GemWeight = 0.72,
                            BuyPrice = 5000000,
                            GemPrice = 6000000
                        },
                        new Gem
                        {
                            GemId = "GE019",
                            GemCode = "JSG-S9",
                            GemName = "Ethiopian Sapphire",
                            GemWeight = 1.3,
                            BuyPrice = 28000000,
                            GemPrice = 32000000
                        },
                        new Gem
                        {
                            GemId = "GE020",
                            GemCode = "JSG-S10",
                            GemName = "Padparadscha Sapphire",
                            GemWeight = 1.0,
                            BuyPrice = 150000000,
                            GemPrice = 180000000
                        },
                    //10 Cabochons
                        new Gem
                        {
                            GemId = "GE021",
                            GemCode = "JSG-C1",
                            GemName = "Moonstone Cabochon",
                            GemWeight = 3.5,
                            BuyPrice = 5000000,
                            GemPrice = 6000000
                        },
                        new Gem
                        {
                            GemId = "GE022",
                            GemCode = "JSG-C2",
                            GemName = "Opal Cabochon",
                            GemWeight = 2.1,
                            BuyPrice = 12000000,
                            GemPrice = 15000000
                        },
                        new Gem
                        {
                            GemId = "GE023",
                            GemCode = "JSG-C3",
                            GemName = "Turquoise Cabochon",
                            GemWeight = 4.7,
                            BuyPrice = 3000000,
                            GemPrice = 4000000
                        },
                        new Gem
                        {
                            GemId = "GE024",
                            GemCode = "JSG-C4",
                            GemName = "Labradorite Cabochon",
                            GemWeight = 5.0,
                            BuyPrice = 2000000,
                            GemPrice = 3000000
                        },
                        new Gem
                        {
                            GemId = "GE025",
                            GemCode = "JSG-C5",
                            GemName = "Star Sapphire Cabochon",
                            GemWeight = 3.2,
                            BuyPrice = 25000000,
                            GemPrice = 30000000
                        },
                        new Gem
                        {
                            GemId = "GE026",
                            GemCode = "JSG-C6",
                            GemName = "Cat's Eye Chrysoberyl Cabochon",
                            GemWeight = 2.5,
                            BuyPrice = 45000000,
                            GemPrice = 52000000
                        },
                        new Gem
                        {
                            GemId = "GE027",
                            GemCode = "JSG-C7",
                            GemName = "Jade Cabochon",
                            GemWeight = 6.8,
                            BuyPrice = 15000000,
                            GemPrice = 18000000
                        },
                        new Gem
                        {
                            GemId = "GE028",
                            GemCode = "JSG-C8",
                            GemName = "Lapis Lazuli Cabochon",
                            GemWeight = 7.5,
                            BuyPrice = 5000000,
                            GemPrice = 6000000
                        },
                        new Gem
                        {
                            GemId = "GE029",
                            GemCode = "JSG-C9",
                            GemName = "Amazonite Cabochon",
                            GemWeight = 4.2,
                            BuyPrice = 2000000,
                            GemPrice = 2500000
                        },
                        new Gem
                        {
                            GemId = "GE030",
                            GemCode = "JSG-C10",
                            GemName = "Garnet Cabochon",
                            GemWeight = 3.0,
                            BuyPrice = 7000000,
                            GemPrice = 8500000
                        },
                    //10 Emeralds
                        new Gem
                        {
                            GemId = "GE031",
                            GemCode = "JSG-E1",
                            GemName = "Colombian Emerald",
                            GemWeight = 1.2,
                            BuyPrice = 50000000,
                            GemPrice = 58000000
                        },
                        new Gem
                        {
                            GemId = "GE032",
                            GemCode = "JSG-E2",
                            GemName = "Zambian Emerald",
                            GemWeight = 2.5,
                            BuyPrice = 120000000,
                            GemPrice = 140000000
                        },
                        new Gem
                        {
                            GemId = "GE033",
                            GemCode = "JSG-E3",
                            GemName = "Brazilian Emerald",
                            GemWeight = 1.8,
                            BuyPrice = 80000000,
                            GemPrice = 92000000
                        },
                        new Gem
                        {
                            GemId = "GE034",
                            GemCode = "JSG-E4",
                            GemName = "Afghan Emerald",
                            GemWeight = 2.2,
                            BuyPrice = 60000000,
                            GemPrice = 75000000
                        },
                        new Gem
                        {
                            GemId = "GE035",
                            GemCode = "JSG-E5",
                            GemName = "Russian Emerald",
                            GemWeight = 1.5,
                            BuyPrice = 70000000,
                            GemPrice = 82000000
                        },
                        new Gem
                        {
                            GemId = "GE036",
                            GemCode = "JSG-E6",
                            GemName = "Synthetic Emerald",
                            GemWeight = 3.0,
                            BuyPrice = 15000000,
                            GemPrice = 18000000
                        },
                        new Gem
                        {
                            GemId = "GE037",
                            GemCode = "JSG-E7",
                            GemName = "Zambian Emerald",
                            GemWeight = 1.1,
                            BuyPrice = 100000000,
                            GemPrice = 120000000
                        },
                        new Gem
                        {
                            GemId = "GE038",
                            GemCode = "JSG-E8",
                            GemName = "Colombian Emerald",
                            GemWeight = 0.9,
                            BuyPrice = 45000000,
                            GemPrice = 52000000
                        },
                        new Gem
                        {
                            GemId = "GE039",
                            GemCode = "JSG-E9",
                            GemName = "Brazilian Emerald",
                            GemWeight = 2.7,
                            BuyPrice = 95000000,
                            GemPrice = 110000000
                        },
                        new Gem
                        {
                            GemId = "GE040",
                            GemCode = "JSG-E10",
                            GemName = "Ethiopian Emerald",
                            GemWeight = 1.3,
                            BuyPrice = 55000000,
                            GemPrice = 65000000
                        },
                    //10 Diamonds
                        new Gem
                        {
                            GemId = "GE041",
                            GemCode = "JSG-D1",
                            GemName = "Round Brilliant Diamond",
                            GemWeight = 1.0,
                            BuyPrice = 150000000,
                            GemPrice = 170000000
                        },
                        new Gem
                        {
                            GemId = "GE042",
                            GemCode = "JSG-D2",
                            GemName = "Princess Cut Diamond",
                            GemWeight = 1.5,
                            BuyPrice = 250000000,
                            GemPrice = 290000000
                        },
                        new Gem
                        {
                            GemId = "GE043",
                            GemCode = "JSG-D3",
                            GemName = "Emerald Cut Diamond",
                            GemWeight = 2.0,
                            BuyPrice = 400000000,
                            GemPrice = 450000000
                        },
                        new Gem
                        {
                            GemId = "GE044",
                            GemCode = "JSG-D4",
                            GemName = "Oval Diamond",
                            GemWeight = 1.2,
                            BuyPrice = 180000000,
                            GemPrice = 210000000
                        },
                        new Gem
                        {
                            GemId = "GE045",
                            GemCode = "JSG-D5",
                            GemName = "Cushion Cut Diamond",
                            GemWeight = 1.8,
                            BuyPrice = 320000000,
                            GemPrice = 370000000
                        },
                        new Gem
                        {
                            GemId = "GE046",
                            GemCode = "JSG-D6",
                            GemName = "Asscher Cut Diamond",
                            GemWeight = 1.3,
                            BuyPrice = 200000000,
                            GemPrice = 230000000
                        },
                        new Gem
                        {
                            GemId = "GE047",
                            GemCode = "JSG-D7",
                            GemName = "Marquise Diamond",
                            GemWeight = 1.6,
                            BuyPrice = 280000000,
                            GemPrice = 320000000
                        },
                        new Gem
                        {
                            GemId = "GE048",
                            GemCode = "JSG-D8",
                            GemName = "Radiant Cut Diamond",
                            GemWeight = 1.1,
                            BuyPrice = 170000000,
                            GemPrice = 200000000
                        },
                        new Gem
                        {
                            GemId = "GE049",
                            GemCode = "JSG-D9",
                            GemName = "Pear Shaped Diamond",
                            GemWeight = 1.4,
                            BuyPrice = 230000000,
                            GemPrice = 270000000
                        },
                        new Gem
                        {
                            GemId = "GE050",
                            GemCode = "JSG-D10",
                            GemName = "Heart Shaped Diamond",
                            GemWeight = 1.0,
                            BuyPrice = 150000000,
                            GemPrice = 180000000
                        }
                );
            });
            modelBuilder.Entity<Gold>(entity =>
            {
                entity.ToTable("gold");
                entity.HasKey(e => e.GoldId);
                entity.Property(e => e.GoldId).HasColumnName("gold_id");
                entity.Property(e => e.GoldName).HasColumnName("gold_name");

                entity.HasData(
                    new Gold { GoldId = "vang24k", GoldName = "24K", GoldCode = "Vàng nữ trang 99,99%" },
                    new Gold { GoldId = "vang18k", GoldName = "18K", GoldCode = "Vàng nữ trang 75%" },
                    new Gold { GoldId = "vang14k", GoldName = "14K", GoldCode = "Vàng nữ trang 58,3%" },
                    new Gold { GoldId = "vang10k", GoldName = "10K", GoldCode = "Vàng nữ trang 41,7%" }
                );
            });

            //config the Product entity with sql server begins here
            modelBuilder.Entity<Product>(entity =>
            {
                // Mapping the properties begins here
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
                entity.Property(e => e.GoldId).HasColumnName("gold_id").IsRequired();
                entity.Property(e => e.GoldWeight).HasColumnName("gold_weight").IsRequired();
                entity.Property(e => e.LaborCost).HasColumnName("labor_cost").IsRequired().HasDefaultValue(0.0);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("GETDATE()");

                entity.HasData(
                new Product
                {
                    ProductId = "P001",
                    ProductCode = "P001",
                    ProductName = "Ruby Necklace",
                    ProductImages = "ruby_necklace.jpg",
                    ProductQuantity = 10,
                    ProductType = "Necklace",
                    ProductWeight = 50.0,
                    ProductWarranty = 12,
                    MarkupRate = 1.2,
                    GemId = "GE001",
                    GoldId = "vang24k",
                    GoldWeight = 45.0,
                    LaborCost = 200.00,
                    CreatedAt = DateTime.Now,
                    UnitPrice = 0,
                    TotalPrice = 0
                },
                new Product
                {
                    ProductId = "P002",
                    ProductCode = "P002",
                    ProductName = "Sapphire Ring",
                    ProductImages = "sapphire_ring.jpg",
                    ProductQuantity = 5,
                    ProductType = "Ring",
                    ProductWeight = 20.0,
                    ProductWarranty = 24,
                    MarkupRate = 1.5,
                    GemId = "GE005",
                    GoldId = "vang10k",
                    GoldWeight = 18.0,
                    LaborCost = 100.00,
                    CreatedAt = DateTime.Now,
                    UnitPrice = 0,
                    TotalPrice = 0
                },
                new Product
                {
                    ProductId = "P003",
                    ProductCode = "P003",
                    ProductName = "Emerald Bracelet",
                    ProductImages = "emerald_bracelet.jpg",
                    ProductQuantity = 8,
                    ProductType = "Bracelet",
                    ProductWeight = 30.0,
                    ProductWarranty = 18,
                    MarkupRate = 1.3,
                    GemId = "GE015",
                    GoldId = "vang24k",
                    GoldWeight = 27.0,
                    LaborCost = 150.00,
                    CreatedAt = DateTime.Now,
                    UnitPrice = 0,
                    TotalPrice = 0
                },
                new Product
                {
                    ProductId = "P004",
                    ProductCode = "P004",
                    ProductName = "Diamond Earrings",
                    ProductImages = "diamond_earrings.jpg",
                    ProductQuantity = 12,
                    ProductType = "Earring",
                    ProductWeight = 15.0,
                    ProductWarranty = 24,
                    MarkupRate = 1.7,
                    GemId = "GE035",
                    GoldId = "vang10k",
                    GoldWeight = 13.5,
                    LaborCost = 180.00,
                    CreatedAt = DateTime.Now,
                    UnitPrice = 0,
                    TotalPrice = 0
                },
                new Product
                {
                    ProductId = "P005",
                    ProductCode = "P005",
                    ProductName = "Topaz Pendant",
                    ProductImages = "topaz_pendant.jpg",
                    ProductQuantity = 20,
                    ProductType = "Necklace",
                    ProductWeight = 10.0,
                    ProductWarranty = 6,
                    MarkupRate = 1.1,
                    GemId = "GE045",
                    GoldId = "vang10k",
                    GoldWeight = 7.5,
                    LaborCost = 90.00,
                    CreatedAt = DateTime.Now,
                    UnitPrice = 0,
                    TotalPrice = 0
                },
                new Product
                {
                    ProductId = "P006",
                    ProductCode = "P006",
                    ProductName = "Ruby Bracelet",
                    ProductImages = "ruby_bracelet.jpg",
                    ProductQuantity = 7,
                    ProductType = "Bracelet",
                    ProductWeight = 25.0,
                    ProductWarranty = 12,
                    MarkupRate = 1.2,
                    GemId = "GE025",
                    GoldId = "vang24k",
                    GoldWeight = 21.0,
                    LaborCost = 130.00,
                    CreatedAt = DateTime.Now,
                    UnitPrice = 0,
                    TotalPrice = 0
                });

            });

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
                entity.HasData(
                    new Discount
                    {
                        DiscountId = "D1",
                        DiscountName = "Summer Sale",
                        OrderType = "Sale",
                        ProductId = "All",
                        ProductType = "All",
                        PublicDate = new DateTime(2024, 6, 1),
                        ExpireDate = new DateTime(2024, 6, 30),
                        DiscountRate = 0.2
                    },
                    new Discount
                    {
                        DiscountId = "D2",
                        DiscountName = "Holiday Promotion",
                        OrderType = "Sale",
                        ProductId = "All",
                        ProductType = "Ring",
                        PublicDate = new DateTime(2024, 11, 15),
                        ExpireDate = new DateTime(2024, 12, 31),
                        DiscountRate = 0.3
                    },
                    new Discount
                    {
                        DiscountId = "D3",
                        DiscountName = "Spring Clearance",
                        OrderType = "Sale",
                        ProductId = "All",
                        ProductType = "Bracelet",
                        PublicDate = new DateTime(2024, 3, 1),
                        ExpireDate = new DateTime(2024, 3, 31),
                        DiscountRate = 0.4
                    },
                    new Discount
                    {
                        DiscountId = "D4",
                        DiscountName = "Back-to-School Sale",
                        OrderType = "Sale",
                        ProductId = "P002",
                        ProductType = "Ring",
                        PublicDate = new DateTime(2024, 8, 1),
                        ExpireDate = new DateTime(2024, 9, 15),
                        DiscountRate = 0.5
                    },
                    new Discount
                    {
                        DiscountId = "D5",
                        DiscountName = "Winter Warm-up",
                        OrderType = "Sale",
                        ProductId = "All",
                        ProductType = "Necklace",
                        PublicDate = new DateTime(2024, 12, 1),
                        ExpireDate = new DateTime(2025, 1, 31),
                        DiscountRate = 0
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
                    new Warranty { WarrantyId = "W3", ProductId = "P3", ProductName = "Product C", StartDate = new DateTime(2023, 3, 1), ExpireDate = new DateTime(2024, 3, 1) },
                    new Warranty { WarrantyId = "W4", ProductId = "P3", ProductName = "Product C", StartDate = new DateTime(2023, 3, 1), ExpireDate = new DateTime(2024, 3, 1) }
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
                    new Customer { CustomerId = "C1", CustomerName = "John Doe", CustomerRank = "Gold", CustomerPoint = 100, AttendDate = new DateTime(2024, 1, 15), CustomerPhone = "012345678" },
                    new Customer { CustomerId = "C2", CustomerName = "Jane Smith", CustomerRank = "Silver", CustomerPoint = 80, AttendDate = new DateTime(2024, 2, 20), CustomerPhone = "012345677" },
                    new Customer { CustomerId = "C3", CustomerName = "Alice Johnson", CustomerRank = "Bronze", CustomerPoint = 50, AttendDate = new DateTime(2024, 3, 25), CustomerPhone = "012345676" },
                    new Customer { CustomerId = "C4", CustomerName = "Bob Brown", CustomerRank = "Bronze", CustomerPoint = 120, AttendDate = new DateTime(2024, 4, 30), CustomerPhone = "012345675" },
                    new Customer { CustomerId = "C5", CustomerName = "Emily Wilson", CustomerRank = "Bronze", CustomerPoint = 90, AttendDate = new DateTime(2024, 5, 5), CustomerPhone = "012345674" }
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
                    new Invoice { InvoiceId = "I1", InvoiceType = "Type A", CustomerId = "C1", UserId = "U1", InvoiceDate = new DateTime(2024, 6, 1), CustomerVoucher = 50.00, TotalPrice = 500.00, EndTotalPrice = 450.00 },
                    new Invoice { InvoiceId = "I2", InvoiceType = "Type B", CustomerId = "C2", UserId = "U2", InvoiceDate = new DateTime(2024, 6, 2), CustomerVoucher = 30.00, TotalPrice = 700.00, EndTotalPrice = 670.00 },
                    new Invoice { InvoiceId = "I3", InvoiceType = "Type C", CustomerId = "C3", UserId = "U3", InvoiceDate = new DateTime(2024, 6, 3), CustomerVoucher = 20.00, TotalPrice = 300.00, EndTotalPrice = 280.00 },
                    new Invoice { InvoiceId = "I4", InvoiceType = "Type D", CustomerId = "C4", UserId = "U1", InvoiceDate = new DateTime(2024, 6, 4), CustomerVoucher = 40.00, TotalPrice = 1000.00, EndTotalPrice = 960.00 },
                    new Invoice { InvoiceId = "I5", InvoiceType = "Type E", CustomerId = "C5", UserId = "U2", InvoiceDate = new DateTime(2024, 6, 5), CustomerVoucher = 60.00, TotalPrice = 800.00, EndTotalPrice = 740.00 }
                );
            });
            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.ToTable("invoice_item");
                entity.HasKey(e => e.InvoiceItemId);
                entity.Property(e => e.InvoiceItemId).HasColumnName("invoice_item_id");
                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id").IsRequired();
                entity.Property(e => e.ProductName).HasColumnName("product_name").IsRequired().HasMaxLength(100);
                entity.Property(e => e.Quantity).HasColumnName("quantity").IsRequired();
                entity.Property(e => e.UnitPrice).HasColumnName("unit_price").IsRequired().HasDefaultValue(0.0);
                entity.Property(e => e.DiscountId).HasColumnName("discount_id").IsRequired();
                entity.Property(e => e.DiscountRate).HasColumnName("discount_rate").IsRequired().HasDefaultValue(0.0);
                entity.Property(e => e.TotalPrice).HasColumnName("total_price").IsRequired().HasDefaultValue(0.0);
                entity.Property(e => e.EndTotalPrice).HasColumnName("end_total_price").IsRequired().HasDefaultValue(0.0);
                entity.Property(e => e.WarrantyId).HasColumnName("warranty_id");

                entity.HasData(
                    new InvoiceItem
                    {
                        InvoiceItemId = "1",
                        InvoiceId = "I1",
                        ProductId = "1",
                        ProductName = "Product 1",
                        Quantity = 2,
                        UnitPrice = 10.50,
                        DiscountId = "1",
                        DiscountRate = 0,
                        TotalPrice = 21.00,
                        EndTotalPrice = 21.00,
                        WarrantyId = "W1",
                    },
                    new InvoiceItem
                    {
                        InvoiceItemId = "2",
                        InvoiceId = "I1",
                        ProductId = "2",
                        ProductName = "Product 2",
                        Quantity = 1,
                        UnitPrice = 25.75,
                        DiscountId = "1",
                        DiscountRate = 0.15,
                        TotalPrice = 21.89,
                        EndTotalPrice = 21.89,
                        WarrantyId = "W2",
                    }
                    );
            });
            modelBuilder.Entity<Stall>(entity =>
            {
                entity.HasData(
                    new Stall
                    {
                        StallId = "S1",
                        UserId = "US3",
                        StaffName = "1",
                        StallDescription = "1",
                        StallName = "Ring",
                        StallType = "Ring"
                    },
                    new Stall
                    {
                        StallId = "S2",
                        UserId = "US4",
                        StaffName = "1",
                        StallDescription = "1",
                        StallName = "Bracelet",
                        StallType = "Bracelet"
                    },
                    new Stall
                    {
                        StallId = "S3",
                        UserId = "US6",
                        StaffName = "1",
                        StallDescription = "1",
                        StallName = "Necklace",
                        StallType = "Necklace"
                    },
                    new Stall
                    {
                        StallId = "S4",
                        UserId = "US7",
                        StaffName = "1",
                        StallDescription = "1",
                        StallName = "Earring",
                        StallType = "Earring"
                    },
                    new Stall
                    {
                        StallId = "S5",
                        UserId = "US8",
                        StaffName = "1",
                        StallDescription = "1",
                        StallName = "Anklet",
                        StallType = "Anklet"
                    }
                    );
            });
            modelBuilder.Entity<StallItem>(entity =>
            {
                entity.HasData(
                    new StallItem { },
                    new StallItem { },
                    new StallItem { },
                    new StallItem { },
                    new StallItem { }
                    );
            });
        }
    }
}
