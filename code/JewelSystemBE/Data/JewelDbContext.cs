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
        public DbSet<StallEmployee> StallEmployees { get; set; }

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

                builder.HasData(
                    new User { UserId = "US1", Username = "user1", Password = BCrypt.Net.BCrypt.HashPassword("password1"), Fullname = "Liam Williams", Email = "liam@gmail.com", Role = "Admin" },
                    new User { UserId = "US2", Username = "user2", Password = BCrypt.Net.BCrypt.HashPassword("password2"), Fullname = "Olivia Miller", Email = "olivia@gmail.com", Role = "Manager" },
                    new User { UserId = "US3", Username = "user3", Password = BCrypt.Net.BCrypt.HashPassword("password3"), Fullname = "James Martinez", Email = "james@gmail.com", Role = "Sale" },
                    new User { UserId = "US4", Username = "user4", Password = BCrypt.Net.BCrypt.HashPassword("password4"), Fullname = "Mateo Martinez", Email = "matao@gmail.com", Role = "Sale" },
                    new User { UserId = "US5", Username = "user5", Password = BCrypt.Net.BCrypt.HashPassword("password5"), Fullname = "Theodore Garcia", Email = "theodore@gmail.com", Role = "Cashier" },
                    new User { UserId = "US6", Username = "user6", Password = BCrypt.Net.BCrypt.HashPassword("password6"), Fullname = "Isabel Rodriguez", Email = "isabel@gmail.com", Role = "Sale" },
                    new User { UserId = "US7", Username = "user7", Password = BCrypt.Net.BCrypt.HashPassword("password7"), Fullname = "Luna Taylor", Email = "luna@gmail.com", Role = "Sale" },
                    new User { UserId = "US8", Username = "user8", Password = BCrypt.Net.BCrypt.HashPassword("password8"), Fullname = "Emma Young", Email = "emma@gmail.com", Role = "Sale" },
                    new User { UserId = "US9", Username = "user9", Password = BCrypt.Net.BCrypt.HashPassword("password9"), Fullname = "Ava Davis", Email = "ava@gmail.com", Role = "Cashier" },
                    new User { UserId = "US10", Username = "user10", Password = BCrypt.Net.BCrypt.HashPassword("password10"), Fullname = "Sophia Wilson", Email = "sophia@gmail.com", Role = "Cashier" },
                    new User { UserId = "US11", Username = "user11", Password = BCrypt.Net.BCrypt.HashPassword("password11"), Fullname = "Charlotte Brown", Email = "charlotte@gmail.com", Role = "Cashier" },
                    new User { UserId = "US12", Username = "user12", Password = BCrypt.Net.BCrypt.HashPassword("password12"), Fullname = "Amelia Jones", Email = "amelia@gmail.com", Role = "Cashier" },
                    new User { UserId = "US13", Username = "user13", Password = BCrypt.Net.BCrypt.HashPassword("password13"), Fullname = "Mia Anderson", Email = "mia@gmail.com", Role = "Sale" },
                    new User { UserId = "US14", Username = "user14", Password = BCrypt.Net.BCrypt.HashPassword("password14"), Fullname = "Harper Thomas", Email = "harper@gmail.com", Role = "Sale" },
                    new User { UserId = "US15", Username = "user15", Password = BCrypt.Net.BCrypt.HashPassword("password15"), Fullname = "Evelyn White", Email = "evelyn@gmail.com", Role = "Sale" },
                    new User { UserId = "US16", Username = "user16", Password = BCrypt.Net.BCrypt.HashPassword("password16"), Fullname = "Abigail Harris", Email = "abigail@gmail.com", Role = "Sale" },
                    new User { UserId = "US17", Username = "user17", Password = BCrypt.Net.BCrypt.HashPassword("password17"), Fullname = "Ella Clark", Email = "ella@gmail.com", Role = "Sale" },
                    new User { UserId = "US18", Username = "user18", Password = BCrypt.Net.BCrypt.HashPassword("password18"), Fullname = "Avery Lewis", Email = "avery@gmail.com", Role = "Sale" }
                );
            });

            modelBuilder.Entity<Jewel>(builder =>
            {
                builder.ToTable("jewel");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).IsRequired();
                builder.Property(x => x.IsComplete).IsRequired().HasDefaultValue(false);

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

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");
                entity.HasKey(e => e.ProductId);
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductCode).HasColumnName("product_code").IsRequired().HasMaxLength(50);
                entity.Property(e => e.ProductName).HasColumnName("product_name").IsRequired().HasMaxLength(100);
                entity.Property(e => e.ProductImages).HasColumnName("product_images").IsRequired();
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
                //P001
                new Product
                {
                    ProductId = "P001",
                    ProductCode = "NEGE00124K",
                    ProductName = "Ruby Necklace NE-R1-24K",
                    ProductImages = "P001.png",
                    ProductQuantity = 10,
                    ProductType = "Necklace",
                    ProductWeight = 50.0,
                    ProductWarranty = 12,
                    MarkupRate = 1.2,
                    GemId = "GE001",
                    GemName = "Natural Mozambique Ruby",
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 45.0,
                    LaborCost = 2000000,
                    CreatedAt = new DateTime(2024, 1, 10),
                },
                //P002
                new Product
                {
                    ProductId = "P002",
                    ProductCode = "NES214K",
                    ProductName = "Sapphire Necklace NE-S2-14K",
                    ProductImages = "P002.png",
                    ProductQuantity = 15,
                    ProductType = "Necklace",
                    ProductWeight = 20.0,
                    ProductWarranty = 12,
                    MarkupRate = 1.15,
                    GemId = "GE012",
                    GemName = "Burmese Sapphire",
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 15.0,
                    LaborCost = 1500000,
                    CreatedAt = new DateTime(2024, 1, 15),
                },
                //P003
                new Product
                {
                    ProductId = "P003",
                    ProductCode = "NEEME03318K",
                    ProductName = "Emerald Earrings NE-EME033-18K",
                    ProductImages = "P003.png",
                    ProductQuantity = 25,
                    ProductType = "Earrings",
                    ProductWeight = 18.0,
                    ProductWarranty = 24,
                    MarkupRate = 1.25,
                    GemId = "GE033",
                    GemName = "Brazilian Emerald",
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 13.0,
                    LaborCost = 1800000,
                    CreatedAt = new DateTime(2024, 1, 9),
                },
                //P004
                new Product
                {
                    ProductId = "P004",
                    ProductCode = "NEDIA04124K",
                    ProductName = "Diamond Ring NE-DIA041-24K",
                    ProductImages = "P004.png",
                    ProductQuantity = 30,
                    ProductType = "Ring",
                    ProductWeight = 25.0,
                    ProductWarranty = 36,
                    MarkupRate = 1.30,
                    GemId = "GE041",
                    GemName = "Round Brilliant Diamond",
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 20.0,
                    LaborCost = 2500000,
                    CreatedAt = new DateTime(2024, 1, 10),
                },
                //P005
                new Product
                {
                    ProductId = "P005",
                    ProductCode = "NERUB00510K",
                    ProductName = "Ruby Bracelet NE-RUB005-10K",
                    ProductImages = "P005.png",
                    ProductQuantity = 20,
                    ProductType = "Bracelet",
                    ProductWeight = 30.0,
                    ProductWarranty = 12,
                    MarkupRate = 1.10,
                    GemId = "GE005",
                    GemName = "Mozambique Ruby",
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 25.0,
                    LaborCost = 2200000,
                    CreatedAt = new DateTime(2024, 1, 10),
                },
                //P006
                new Product
                {
                    ProductId = "P006",
                    ProductCode = "NEEMA04618K",
                    ProductName = "Diamond Necklace NE-EMA046-24K",
                    ProductImages = "P006.png",
                    ProductQuantity = 10,
                    ProductType = "Necklace",
                    ProductWeight = 45.0,
                    ProductWarranty = 24,
                    MarkupRate = 1.35,
                    GemId = "GE046",
                    GemName = "Asscher Cut Diamond",
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 40.0,
                    LaborCost = 3000000,
                    CreatedAt = new DateTime(2024, 1, 1),
                },
                //P007
                new Product
                {
                    ProductId = "P007",
                    ProductCode = "NESAP01324K",
                    ProductName = "Sapphire Ring NE-SAP013-24K",
                    ProductImages = "P007.png",
                    ProductQuantity = 12,
                    ProductType = "Ring",
                    ProductWeight = 22.0,
                    ProductWarranty = 18,
                    MarkupRate = 1.20,
                    GemId = "GE013",
                    GemName = "Madagascar Sapphire",
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 17.0,
                    LaborCost = 2000000,
                    CreatedAt = new DateTime(2024, 1, 3),
                },
                //P008
                new Product
                {
                    ProductId = "P008",
                    ProductCode = "NEEME03414K",
                    ProductName = "Emerald Necklace NE-EME034-14K",
                    ProductImages = "P008.png",
                    ProductQuantity = 20,
                    ProductType = "Necklace",
                    ProductWeight = 18.5,
                    ProductWarranty = 12,
                    MarkupRate = 1.15,
                    GemId = "GE034",
                    GemName = "Afghan Emerald",
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 14.0,
                    LaborCost = 1700000,
                    CreatedAt = new DateTime(2024, 1, 8),
                },
                //P009
                new Product
                {
                    ProductId = "P009",
                    ProductCode = "NEDIA04318K",
                    ProductName = "Diamond Earrings NE-DIA043-24K",
                    ProductImages = "P009.png",
                    ProductQuantity = 18,
                    ProductType = "Earrings",
                    ProductWeight = 27.0,
                    ProductWarranty = 24,
                    MarkupRate = 1.25,
                    GemId = "GE043",
                    GemName = "Emerald Cut Diamond",
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 22.0,
                    LaborCost = 2300000,
                    CreatedAt = new DateTime(2024, 1, 10),
                },
                //P010
                new Product
                {
                    ProductId = "P010",
                    ProductCode = "NERUB00310K",
                    ProductName = "Ruby Ring NE-RUB003-10K",
                    ProductImages = "P010.png",
                    ProductQuantity = 15,
                    ProductType = "Ring",
                    ProductWeight = 20.0,
                    ProductWarranty = 12,
                    MarkupRate = 1.10,
                    GemId = "GE003",
                    GemName = "Thai Ruby",
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 16.0,
                    LaborCost = 1600000,
                    CreatedAt = new DateTime(2024, 1, 19),
                },
                //P011
                new Product
                {
                    ProductId = "P011",
                    ProductCode = "NESAP01418K",
                    ProductName = "Sapphire Bracelet NE-SAP014-18K",
                    ProductImages = "P011.png",
                    ProductQuantity = 22,
                    ProductType = "Bracelet",
                    ProductWeight = 30.0,
                    ProductWarranty = 18,
                    MarkupRate = 1.22,
                    GemId = "GE014",
                    GemName = "Australian Sapphire",
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 25.0,
                    LaborCost = 2100000,
                    CreatedAt = new DateTime(2024, 1, 22),
                },
                //P012
                new Product
                {
                    ProductId = "P012",
                    ProductCode = "NEEME03124K",
                    ProductName = "Emerald Necklace NE-EME031-24K",
                    ProductImages = "P012.png",
                    ProductQuantity = 10,
                    ProductType = "Necklace",
                    ProductWeight = 40.0,
                    ProductWarranty = 24,
                    MarkupRate = 1.30,
                    GemId = "GE031",
                    GemName = "Colombian Emerald",
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 35.0,
                    LaborCost = 2700000,
                    CreatedAt = new DateTime(2024, 1, 28),
                },
                //P013
                new Product
                {
                    ProductId = "P013",
                    ProductCode = "NERUB00414K",
                    ProductName = "Ruby Earrings NE-RUB004-14K",
                    ProductImages = "P013.png",
                    ProductQuantity = 14,
                    ProductType = "Earrings",
                    ProductWeight = 20.0,
                    ProductWarranty = 12,
                    MarkupRate = 1.18,
                    GemId = "GE004",
                    GemName = "India Ruby",
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 16.0,
                    LaborCost = 1800000,
                    CreatedAt = new DateTime(2024, 1, 11),
                },
                //P014
                new Product
                {
                    ProductId = "P014",
                    ProductCode = "NESAP01518K",
                    ProductName = "Sapphire Necklace NE-SAP015-18K",
                    ProductImages = "P014.png",
                    ProductQuantity = 8,
                    ProductType = "Necklace",
                    ProductWeight = 42.0,
                    ProductWarranty = 24,
                    MarkupRate = 1.35,
                    GemId = "GE015",
                    GemName = "Kashmir Sapphire",
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 37.0,
                    LaborCost = 2800000,
                    CreatedAt = new DateTime(2024, 1, 5),
                },
                //P015
                new Product
                {
                    ProductId = "P015",
                    ProductCode = "NEDIA04414K",
                    ProductName = "Diamond Necklace NE-DIA044-24K",
                    ProductImages = "P015.png",
                    ProductQuantity = 16,
                    ProductType = "Necklace",
                    ProductWeight = 24.0,
                    ProductWarranty = 18,
                    MarkupRate = 1.28,
                    GemId = "GE044",
                    GemName = "Oval Diamond",
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 20.0,
                    LaborCost = 2400000,
                    CreatedAt = new DateTime(2024, 1, 10),
                },
                //P016
                new Product
                {
                    ProductId = "P016",
                    ProductCode = "NEEME03510K",
                    ProductName = "Emerald Bracelet NE-EME035-10K",
                    ProductImages = "P016.png",
                    ProductQuantity = 18,
                    ProductType = "Bracelet",
                    ProductWeight = 30.0,
                    ProductWarranty = 12,
                    MarkupRate = 1.22,
                    GemId = "GE035",
                    GemName = "Russian Emerald",
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 25.0,
                    LaborCost = 1900000,
                    CreatedAt = new DateTime(2024, 1, 5),
                },
                //P017
                new Product
                {
                    ProductId = "P017",
                    ProductCode = "NEDIA04524K",
                    ProductName = "Diamond Bracelet NE-DIA045-24K",
                    ProductImages = "P017.png",
                    ProductQuantity = 12,
                    ProductType = "Bracelet",
                    ProductWeight = 35.0,
                    ProductWarranty = 36,
                    MarkupRate = 1.30,
                    GemId = "GE045",
                    GemName = "Cushion Cut Diamond",
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 30.0,
                    LaborCost = 2900000,
                    CreatedAt = new DateTime(2024, 1, 10),
                },
                //P018
                new Product
                {
                    ProductId = "P018",
                    ProductCode = "NEEME03218K",
                    ProductName = "Emerald Ring NE-EME032-18K",
                    ProductImages = "P018.png",
                    ProductQuantity = 15,
                    ProductType = "Ring",
                    ProductWeight = 22.0,
                    ProductWarranty = 24,
                    MarkupRate = 1.25,
                    GemId = "GE032",
                    GemName = "Zambian Emerald",
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 17.0,
                    LaborCost = 2300000,
                    CreatedAt = new DateTime(2024, 1, 2),
                },
                //P019
                new Product
                {
                    ProductId = "P019",
                    ProductCode = "NERUB00214K",
                    ProductName = "Ruby Necklace NE-RUB002-14K",
                    ProductImages = "P019.png",
                    ProductQuantity = 10,
                    ProductType = "Necklace",
                    ProductWeight = 45.0,
                    ProductWarranty = 24,
                    MarkupRate = 1.28,
                    GemId = "GE002",
                    GemName = "Burmese Ruby",
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 40.0,
                    LaborCost = 2700000,
                    CreatedAt = new DateTime(2024, 1, 5),
                },
                //P020
                new Product
                {
                    ProductId = "P020",
                    ProductCode = "NESAP01110K",
                    ProductName = "Sapphire Earrings NE-SAP011-10K",
                    ProductImages = "P020.png",
                    ProductQuantity = 20,
                    ProductType = "Earrings",
                    ProductWeight = 20.0,
                    ProductWarranty = 18,
                    MarkupRate = 1.15,
                    GemId = "GE011",
                    GemName = "Natural Ceylon Sapphire",
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 16.0,
                    LaborCost = 1600000,
                    CreatedAt = new DateTime(2024, 1, 9),
                },
                //P021
                new Product
                {
                    ProductId = "P021",
                    ProductCode = "NEEMA04114K",
                    ProductName = "Diamond Earrings NE-EMA041-24K",
                    ProductImages = "P021.png",
                    ProductQuantity = 18,
                    ProductType = "Earrings",
                    ProductWeight = 22.0,
                    ProductWarranty = 24,
                    MarkupRate = 1.20,
                    GemId = "GE041",
                    GemName = "Round Brilliant Diamond",
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 18.0,
                    LaborCost = 2000000,
                    CreatedAt = new DateTime(2024, 1, 16),
                },

                // Data generated automatically - 40 seeds
                new Product
                {
                    ProductId = "P022",
                    ProductCode = "",
                    ProductName = "Pear Shaped Diamond Earrings",
                    ProductImages = "P022.png",
                    ProductQuantity = 12,
                    ProductType = "Earrings",
                    ProductWeight = 4.807237836121708,
                    ProductWarranty = 28,
                    MarkupRate = 1.8840143924302741,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 3.042794759899173,
                    GemId = "GE049",
                    GemName = "Pear Shaped Diamond",
                    GemWeight = 1.4,
                    LaborCost = 12218864.894510968,
                    CreatedAt = new DateTime(2024, 1, 13)
                }, new Product
                {
                    ProductId = "P023",
                    ProductCode = "674204419049",
                    ProductName = "Russian Emerald Ring",
                    ProductImages = "P023.png",
                    ProductQuantity = 15,
                    ProductType = "Ring",
                    ProductWeight = 5.148751792826632,
                    ProductWarranty = 35,
                    MarkupRate = 1.58566250942251,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 3.397609558032495,
                    GemId = "GE035",
                    GemName = "Russian Emerald",
                    GemWeight = 1.5,
                    LaborCost = 43235443.70112606,
                    CreatedAt = new DateTime(2024, 1, 20)
                }, new Product
                {
                    ProductId = "P024",
                    ProductCode = "862178701237",
                    ProductName = "Natural Ceylon Sapphire Earrings",
                    ProductImages = "P024.png",
                    ProductQuantity = 17,
                    ProductType = "Earrings",
                    ProductWeight = 5.825956130083856,
                    ProductWarranty = 18,
                    MarkupRate = 1.045675402349213,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 3.70310085372937,
                    GemId = "GE011",
                    GemName = "Natural Ceylon Sapphire",
                    GemWeight = 1.02,
                    LaborCost = 20255374.45038518,
                    CreatedAt = new DateTime(2024, 1, 10)
                }, new Product
                {
                    ProductId = "P025",
                    ProductCode = "428617280256",
                    ProductName = "Princess Cut Diamond Bracelet",
                    ProductImages = "P025.png",
                    ProductQuantity = 14,
                    ProductType = "Bracelet",
                    ProductWeight = 5.285126368972044,
                    ProductWarranty = 43,
                    MarkupRate = 2.972447747762415,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 3.443876334585762,
                    GemId = "GE042",
                    GemName = "Princess Cut Diamond",
                    GemWeight = 1.5,
                    LaborCost = 6533141.621613235,
                    CreatedAt = new DateTime(2024, 1, 8)
                }, 
                new Product
                {
                    ProductId = "P026",
                    ProductCode = "670169156688",
                    ProductName = "Radiant Cut Diamond Earrings",
                    ProductImages = "P026.png",
                    ProductQuantity = 16,
                    ProductType = "Earrings",
                    ProductWeight = 10.762794066397113,
                    ProductWarranty = 16,
                    MarkupRate = 1.7085622340187063,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 8.547652135144292,
                    GemId = "GE048",
                    GemName = "Radiant Cut Diamond",
                    GemWeight = 1.1,
                    LaborCost = 8586437.999674894,
                    CreatedAt = new DateTime(2024, 1, 3)
                }, new Product
                {
                    ProductId = "P027",
                    ProductCode = "829988629120",
                    ProductName = "Colombian Emerald Earrings",
                    ProductImages = "P027.png",
                    ProductQuantity = 14,
                    ProductType = "Earrings",
                    ProductWeight = 6.618036132964373,
                    ProductWarranty = 19,
                    MarkupRate = 1.59993305674788,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 3.249816075238458,
                    GemId = "GE031",
                    GemName = "Colombian Emerald",
                    GemWeight = 1.2,
                    LaborCost = 1375258.8754988282,
                    CreatedAt = new DateTime(2024, 1, 22)
                }, new Product
                {
                    ProductId = "P028",
                    ProductCode = "633028312781",
                    ProductName = "Padparadscha Sapphire Ring",
                    ProductImages = "P028.png",
                    ProductQuantity = 7,
                    ProductType = "Ring",
                    ProductWeight = 4.749480286791609,
                    ProductWarranty = 20,
                    MarkupRate = 2.608043220378293,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 3.0781166668032323,
                    GemId = "GE020",
                    GemName = "Padparadscha Sapphire",
                    GemWeight = 1,
                    LaborCost = 37289462.66607901,
                    CreatedAt = new DateTime(2024, 1, 29)
                }, new Product
                {
                    ProductId = "P029",
                    ProductCode = "730263125687",
                    ProductName = "Garnet Cabochon Necklace",
                    ProductImages = "P029.png",
                    ProductQuantity = 14,
                    ProductType = "Necklace",
                    ProductWeight = 7.514552739103244,
                    ProductWarranty = 25,
                    MarkupRate = 1.0150129584628296,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 4.498767340919102,
                    GemId = "GE030",
                    GemName = "Garnet Cabochon",
                    GemWeight = 3,
                    LaborCost = 44583675.93773114,
                    CreatedAt = new DateTime(2024, 1, 11)
                }, 
                new Product
                {
                    ProductId = "P030",
                    ProductCode = "901788122324",
                    ProductName = "Brazilian Emerald Necklace",
                    ProductImages = "P030.png",
                    ProductQuantity = 12,
                    ProductType = "Necklace",
                    ProductWeight = 5.978778889249457,
                    ProductWarranty = 15,
                    MarkupRate = 1.1401401775578925,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 2.711575205296207,
                    GemId = "GE039",
                    GemName = "Brazilian Emerald",
                    GemWeight = 2.7,
                    LaborCost = 2445534.0691606943,
                    CreatedAt = new DateTime(2024, 1, 26)
                }, new Product
                {
                    ProductId = "P031",
                    ProductCode = "870534791152",
                    ProductName = "Synthetic Emerald Bracelet",
                    ProductImages = "P031.png",
                    ProductQuantity = 12,
                    ProductType = "Bracelet",
                    ProductWeight = 7.89961411082806,
                    ProductWarranty = 46,
                    MarkupRate = 2.7326722773575503,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 3.4989526307700163,
                    GemId = "GE036",
                    GemName = "Synthetic Emerald",
                    GemWeight = 3,
                    LaborCost = 23573781.627794143,
                    CreatedAt = new DateTime(2024, 1, 8)
                }, new Product
                {
                    ProductId = "P032",
                    ProductCode = "816946302009",
                    ProductName = "Pear Shaped Diamond Ring",
                    ProductImages = "P032.png",
                    ProductQuantity = 22,
                    ProductType = "Ring",
                    ProductWeight = 9.391879362217212,
                    ProductWarranty = 41,
                    MarkupRate = 2.6984438757492146,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 7.854970006985199,
                    GemId = "GE049",
                    GemName = "Pear Shaped Diamond",
                    GemWeight = 1.4,
                    LaborCost = 30841391.562616978,
                    CreatedAt = new DateTime(2024, 1, 11)
                }, new Product
                {
                    ProductId = "P033",
                    ProductCode = "610464781825",
                    ProductName = "Brazilian Emerald Ring",
                    ProductImages = "P033.png",
                    ProductQuantity = 21,
                    ProductType = "Ring",
                    ProductWeight = 5.031723641860203,
                    ProductWarranty = 21,
                    MarkupRate = 1.004876605607548,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 1.5895821041883988,
                    GemId = "GE033",
                    GemName = "Brazilian Emerald",
                    GemWeight = 1.8,
                    LaborCost = 11699620.78143068,
                    CreatedAt = new DateTime(2024, 1, 26)
                }, 
                new Product
                {
                    ProductId = "P034",
                    ProductCode = "762407690611",
                    ProductName = "Radiant Cut Diamond Bracelet",
                    ProductImages = "P034.png",
                    ProductQuantity = 8,
                    ProductType = "Bracelet",
                    ProductWeight = 11.992138786457193,
                    ProductWarranty = 22,
                    MarkupRate = 2.6536883297093854,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 9.408474767631787,
                    GemId = "GE048",
                    GemName = "Radiant Cut Diamond",
                    GemWeight = 1.1,
                    LaborCost = 4180201.6651579402,
                    CreatedAt = new DateTime(2024, 1, 16)
                }, new Product
                {
                    ProductId = "P035",
                    ProductCode = "231569490190",
                    ProductName = "Oval Diamond Necklace",
                    ProductImages = "P035.png",
                    ProductQuantity = 16,
                    ProductType = "Necklace",
                    ProductWeight = 6.176482890493749,
                    ProductWarranty = 35,
                    MarkupRate = 1.6047853756229071,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 2.072623320002408,
                    GemId = "GE044",
                    GemName = "Oval Diamond",
                    GemWeight = 1.2,
                    LaborCost = 3572618.954896469,
                    CreatedAt = new DateTime(2024, 1, 23)
                }, new Product
                {
                    ProductId = "P036",
                    ProductCode = "630624866041",
                    ProductName = "Brazilian Emerald Bracelet",
                    ProductImages = "P036.png",
                    ProductQuantity = 18,
                    ProductType = "Bracelet",
                    ProductWeight = 14.04223322239628,
                    ProductWarranty = 47,
                    MarkupRate = 2.8969498751521985,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 8.910727993824992,
                    GemId = "GE039",
                    GemName = "Brazilian Emerald",
                    GemWeight = 2.7,
                    LaborCost = 39438265.041138254,
                    CreatedAt = new DateTime(2024, 1, 30)
                }, new Product
                {
                    ProductId = "P037",
                    ProductCode = "427057894494",
                    ProductName = "Moonstone Cabochon Bracelet",
                    ProductImages = "P037.png",
                    ProductQuantity = 13,
                    ProductType = "Bracelet",
                    ProductWeight = 13.136524250093027,
                    ProductWarranty = 39,
                    MarkupRate = 1.9103063365760704,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 7.674282906181705,
                    GemId = "GE021",
                    GemName = "Moonstone Cabochon",
                    GemWeight = 3.5,
                    LaborCost = 19100700.2069338,
                    CreatedAt = new DateTime(2024, 1, 20)
                }, 
                new Product
                {
                    ProductId = "P038",
                    ProductCode = "719461390533",
                    ProductName = "Thai Sapphire Necklace",
                    ProductImages = "P038.png",
                    ProductQuantity = 23,
                    ProductType = "Necklace",
                    ProductWeight = 5.559736255014135,
                    ProductWarranty = 29,
                    MarkupRate = 1.1076850835844394,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 1.4517318691161973,
                    GemId = "GE017",
                    GemName = "Thai Sapphire",
                    GemWeight = 1.8,
                    LaborCost = 25417389.08495232,
                    CreatedAt = new DateTime(2024, 1, 10)
                }, new Product
                {
                    ProductId = "P039",
                    ProductCode = "186487133888",
                    ProductName = "Heated Natural Ruby Ring",
                    ProductImages = "P039.png",
                    ProductQuantity = 24,
                    ProductType = "Ring",
                    ProductWeight = 6.513648213681464,
                    ProductWarranty = 18,
                    MarkupRate = 2.6640068376294783,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 3.606986572569416,
                    GemId = "GE006",
                    GemName = "Heated Natural Ruby",
                    GemWeight = 0.34,
                    LaborCost = 26270393.562470425,
                    CreatedAt = new DateTime(2024, 1, 26)
                }, new Product
                {
                    ProductId = "P040",
                    ProductCode = "794088504470",
                    ProductName = "Natural Ceylon Sapphire Bracelet",
                    ProductImages = "P040.png",
                    ProductQuantity = 18,
                    ProductType = "Bracelet",
                    ProductWeight = 11.748285931737238,
                    ProductWarranty = 43,
                    MarkupRate = 2.1763476154150325,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 9.166335198076375,
                    GemId = "GE011",
                    GemName = "Natural Ceylon Sapphire",
                    GemWeight = 1.02,
                    LaborCost = 18924204.050375704,
                    CreatedAt = new DateTime(2024, 1, 19)
                }, new Product
                {
                    ProductId = "P041",
                    ProductCode = "660680543120",
                    ProductName = "Opal Cabochon Bracelet",
                    ProductImages = "P041.png",
                    ProductQuantity = 12,
                    ProductType = "Bracelet",
                    ProductWeight = 5.71881242124837,
                    ProductWarranty = 29,
                    MarkupRate = 1.3533459210371506,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 1.4518589504348511,
                    GemId = "GE022",
                    GemName = "Opal Cabochon",
                    GemWeight = 2.1,
                    LaborCost = 39783324.08696133,
                    CreatedAt = new DateTime(2024, 1, 15)
                }, 
                new Product
                {
                    ProductId = "P042",
                    ProductCode = "366177263281",
                    ProductName = "Brazilian Emerald Earrings",
                    ProductImages = "P042.png",
                    ProductQuantity = 21,
                    ProductType = "Earrings",
                    ProductWeight = 4.13003820531666,
                    ProductWarranty = 19,
                    MarkupRate = 1.4945676533281764,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 1.2742085596804833,
                    GemId = "GE039",
                    GemName = "Brazilian Emerald",
                    GemWeight = 2.7,
                    LaborCost = 31800804.722350467,
                    CreatedAt = new DateTime(2024, 1, 2)
                }, new Product
                {
                    ProductId = "P043",
                    ProductCode = "164695297436",
                    ProductName = "Natural Ceylon Sapphire Bracelet",
                    ProductImages = "P043.png",
                    ProductQuantity = 10,
                    ProductType = "Bracelet",
                    ProductWeight = 5.822323224641309,
                    ProductWarranty = 32,
                    MarkupRate = 1.0517502056142054,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 4.793143655495984,
                    GemId = "GE011",
                    GemName = "Natural Ceylon Sapphire",
                    GemWeight = 1.02,
                    LaborCost = 21576589.51445539,
                    CreatedAt = new DateTime(2024, 1, 27)
                }, new Product
                {
                    ProductId = "P044",
                    ProductCode = "466485346360",
                    ProductName = "Round Brilliant Diamond Necklace",
                    ProductImages = "P044.png",
                    ProductQuantity = 11,
                    ProductType = "Necklace",
                    ProductWeight = 7.8327010529136505,
                    ProductWarranty = 15,
                    MarkupRate = 2.7528004545662834,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 5.914430100910993,
                    GemId = "GE041",
                    GemName = "Round Brilliant Diamond",
                    GemWeight = 1,
                    LaborCost = 45688334.09528934,
                    CreatedAt = new DateTime(2024, 1, 16)
                }, new Product
                {
                    ProductId = "P045",
                    ProductCode = "383869345739",
                    ProductName = "Colombian Emerald Ring",
                    ProductImages = "P045.png",
                    ProductQuantity = 7,
                    ProductType = "Ring",
                    ProductWeight = 6.853213813607989,
                    ProductWarranty = 41,
                    MarkupRate = 1.8176659611941688,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 5.127997649240241,
                    GemId = "GE031",
                    GemName = "Colombian Emerald",
                    GemWeight = 1.2,
                    LaborCost = 3652522.4423296447,
                    CreatedAt = new DateTime(2024, 1, 29)
                },
                new Product
                {
                    ProductId = "P046",
                    ProductCode = "231003630530",
                    ProductName = "Garnet Cabochon Ring",
                    ProductImages = "P046.png",
                    ProductQuantity = 6,
                    ProductType = "Ring",
                    ProductWeight = 12.430393848269079,
                    ProductWarranty = 38,
                    MarkupRate = 2.6778426540134204,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 6.548154890794476,
                    GemId = "GE030",
                    GemName = "Garnet Cabochon",
                    GemWeight = 3,
                    LaborCost = 7315325.622572417,
                    CreatedAt = new DateTime(2024, 1, 27)
                }, new Product
                {
                    ProductId = "P047",
                    ProductCode = "949651291774",
                    ProductName = "Madagascar Sapphire Bracelet",
                    ProductImages = "P047.png",
                    ProductQuantity = 18,
                    ProductType = "Bracelet",
                    ProductWeight = 10.638862761839402,
                    ProductWarranty = 30,
                    MarkupRate = 2.1308457513069903,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 9.135071775965262,
                    GemId = "GE013",
                    GemName = "Madagascar Sapphire",
                    GemWeight = 1.5,
                    LaborCost = 36773026.53172834,
                    CreatedAt = new DateTime(2024, 1, 19)
                }, new Product
                {
                    ProductId = "P048",
                    ProductCode = "197592618896",
                    ProductName = "India Ruby Necklace",
                    ProductImages = "P048.png",
                    ProductQuantity = 17,
                    ProductType = "Necklace",
                    ProductWeight = 13.988171237491485,
                    ProductWarranty = 31,
                    MarkupRate = 2.91390166933939,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 5.711292056308791,
                    GemId = "GE004",
                    GemName = "India Ruby",
                    GemWeight = 5.91,
                    LaborCost = 40130088.610135965,
                    CreatedAt = new DateTime(2024, 1, 26)
                }, new Product
                {
                    ProductId = "P049",
                    ProductCode = "467794567861",
                    ProductName = "Ethiopian Sapphire Bracelet",
                    ProductImages = "P049.png",
                    ProductQuantity = 9,
                    ProductType = "Bracelet",
                    ProductWeight = 8.385374392527947,
                    ProductWarranty = 19,
                    MarkupRate = 1.8406804973503976,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 6.966732255242682,
                    GemId = "GE019",
                    GemName = "Ethiopian Sapphire",
                    GemWeight = 1.3,
                    LaborCost = 27063957.402623728,
                    CreatedAt = new DateTime(2024, 1, 30)
                }, 
                new Product
                {
                    ProductId = "P050",
                    ProductCode = "838026328454",
                    ProductName = "Australian Sapphire Ring",
                    ProductImages = "P050.png",
                    ProductQuantity = 10,
                    ProductType = "Ring",
                    ProductWeight = 8.54438414684569,
                    ProductWarranty = 25,
                    MarkupRate = 1.1524591313630836,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 4.8415670016816,
                    GemId = "GE014",
                    GemName = "Australian Sapphire",
                    GemWeight = 3.2,
                    LaborCost = 37693764.75196147,
                    CreatedAt = new DateTime(2024, 1, 22)
                }, new Product
                {
                    ProductId = "P051",
                    ProductCode = "596836381399",
                    ProductName = "Heart Shaped Diamond Necklace",
                    ProductImages = "P051.png",
                    ProductQuantity = 12,
                    ProductType = "Necklace",
                    ProductWeight = 2.635610655715247,
                    ProductWarranty = 22,
                    MarkupRate = 2.818804308589629,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 1.337046909032949,
                    GemId = "GE050",
                    GemName = "Heart Shaped Diamond",
                    GemWeight = 1,
                    LaborCost = 44783583.40441224,
                    CreatedAt = new DateTime(2024, 1, 6)
                }, new Product
                {
                    ProductId = "P052",
                    ProductCode = "512360707805",
                    ProductName = "Round Brilliant Diamond Earrings",
                    ProductImages = "P052.png",
                    ProductQuantity = 20,
                    ProductType = "Earrings",
                    ProductWeight = 5.776072824534776,
                    ProductWarranty = 45,
                    MarkupRate = 1.5343275103208867,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 1.7854832402627365,
                    GemId = "GE041",
                    GemName = "Round Brilliant Diamond",
                    GemWeight = 1,
                    LaborCost = 18740482.320073944,
                    CreatedAt = new DateTime(2024, 1, 22)
                }, new Product
                {
                    ProductId = "P053",
                    ProductCode = "170516697530",
                    ProductName = "Emerald Cut Diamond Ring",
                    ProductImages = "P053.png",
                    ProductQuantity = 10,
                    ProductType = "Ring",
                    ProductWeight = 3.789808344608001,
                    ProductWarranty = 17,
                    MarkupRate = 2.573757148600832,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 1.6261364372426415,
                    GemId = "GE043",
                    GemName = "Emerald Cut Diamond",
                    GemWeight = 2,
                    LaborCost = 38467110.61990011,
                    CreatedAt = new DateTime(2024, 1, 8)
                }, 
                new Product
                {
                    ProductId = "P054",
                    ProductCode = "814881347466",
                    ProductName = "Moonstone Cabochon Earrings",
                    ProductImages = "P054.png",
                    ProductQuantity = 8,
                    ProductType = "Earrings",
                    ProductWeight = 15.754298331285687,
                    ProductWarranty = 15,
                    MarkupRate = 1.760300849155109,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 9.935502620295331,
                    GemId = "GE021",
                    GemName = "Moonstone Cabochon",
                    GemWeight = 3.5,
                    LaborCost = 20285142.942025773,
                    CreatedAt = new DateTime(2024, 1, 30)
                }, new Product
                {
                    ProductId = "P055",
                    ProductCode = "890509691739",
                    ProductName = "Montana Sapphire Necklace",
                    ProductImages = "P055.png",
                    ProductQuantity = 12,
                    ProductType = "Necklace",
                    ProductWeight = 11.427962360843086,
                    ProductWarranty = 27,
                    MarkupRate = 2.2033386258169805,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 8.69206692211337,
                    GemId = "GE018",
                    GemName = "Montana Sapphire",
                    GemWeight = 0.72,
                    LaborCost = 22229931.668697417,
                    CreatedAt = new DateTime(2024, 1, 19)
                }, new Product
                {
                    ProductId = "P056",
                    ProductCode = "529134568958",
                    ProductName = "Oval Diamond Ring",
                    ProductImages = "P056.png",
                    ProductQuantity = 11,
                    ProductType = "Ring",
                    ProductWeight = 9.240520721573136,
                    ProductWarranty = 16,
                    MarkupRate = 1.010838790324708,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 7.6271642229012775,
                    GemId = "GE044",
                    GemName = "Oval Diamond",
                    GemWeight = 1.2,
                    LaborCost = 13235448.229500482,
                    CreatedAt = new DateTime(2024, 1, 23)
                }, new Product
                {
                    ProductId = "P057",
                    ProductCode = "171920122186",
                    ProductName = "Ethiopian Emerald Bracelet",
                    ProductImages = "P057.png",
                    ProductQuantity = 22,
                    ProductType = "Bracelet",
                    ProductWeight = 6.641087429115302,
                    ProductWarranty = 14,
                    MarkupRate = 1.568168533711181,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 5.023662067658912,
                    GemId = "GE040",
                    GemName = "Ethiopian Emerald",
                    GemWeight = 1.3,
                    LaborCost = 2290639.533413939,
                    CreatedAt = new DateTime(2024, 1, 27)
                }, 
                new Product
                {
                    ProductId = "P058",
                    ProductCode = "849475227946",
                    ProductName = "Australian Sapphire Earrings",
                    ProductImages = "P058.png",
                    ProductQuantity = 12,
                    ProductType = "Earrings",
                    ProductWeight = 6.19172427226904,
                    ProductWarranty = 16,
                    MarkupRate = 2.976084867296785,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 2.1373953928147498,
                    GemId = "GE014",
                    GemName = "Australian Sapphire",
                    GemWeight = 3.2,
                    LaborCost = 35214561.04589756,
                    CreatedAt = new DateTime(2024, 1, 12)
                }, new Product
                {
                    ProductId = "P059",
                    ProductCode = "383905492512",
                    ProductName = "Labradorite Cabochon Bracelet",
                    ProductImages = "P059.png",
                    ProductQuantity = 10,
                    ProductType = "Bracelet",
                    ProductWeight = 14.430716366025056,
                    ProductWarranty = 23,
                    MarkupRate = 1.824163888733295,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 8.95471168475618,
                    GemId = "GE024",
                    GemName = "Labradorite Cabochon",
                    GemWeight = 5,
                    LaborCost = 21302530.900030572,
                    CreatedAt = new DateTime(2024, 1, 1)
                }, new Product
                {
                    ProductId = "P060",
                    ProductCode = "875404298027",
                    ProductName = "Pear Shaped Diamond Necklace",
                    ProductImages = "P060.png",
                    ProductQuantity = 11,
                    ProductType = "Necklace",
                    ProductWeight = 4.5761415534657655,
                    ProductWarranty = 30,
                    MarkupRate = 1.441549319093442,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 2.96134934542507,
                    GemId = "GE049",
                    GemName = "Pear Shaped Diamond",
                    GemWeight = 1.4,
                    LaborCost = 13184353.139635505,
                    CreatedAt = new DateTime(2024, 1, 2)
                }, new Product
                {
                    ProductId = "P061",
                    ProductCode = "474280836261",
                    ProductName = "Natural Mozambique Ruby Ring",
                    ProductImages = "P061.png",
                    ProductQuantity = 23,
                    ProductType = "Ring",
                    ProductWeight = 7.543572562571369,
                    ProductWarranty = 16,
                    MarkupRate = 2.5408466176827234,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 5.09643416581116,
                    GemId = "GE001",
                    GemName = "Natural Mozambique Ruby",
                    GemWeight = 0.98,
                    LaborCost = 28780291.704716213,
                    CreatedAt = new DateTime(2024, 1, 27)
                }
                );

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
                    // For All type, All ID
                        new Discount
                        {
                            DiscountId = "D1",
                            DiscountName = "Elegance",
                            OrderType = "Sale",
                            ProductId = "All",
                            ProductType = "All",
                            PublicDate = new DateTime(2024, 6, 25),
                            ExpireDate = new DateTime(2024, 8, 25),
                            DiscountRate = 0.12
                        },
                        new Discount // in future
                        {
                            DiscountId = "D2",
                            DiscountName = "Winter Warm-Up",
                            OrderType = "Sale",
                            ProductId = "All",
                            ProductType = "All",
                            PublicDate = new DateTime(2024, 12, 1),
                            ExpireDate = new DateTime(2024, 12, 31),
                            DiscountRate = 0.05
                        },
                        new Discount // expired
                        {
                            DiscountId = "D3",
                            DiscountName = "Spring Special",
                            OrderType = "Sale",
                            ProductId = "All",
                            ProductType = "All",
                            PublicDate = new DateTime(2024, 3, 1),
                            ExpireDate = new DateTime(2024, 3, 30),
                            DiscountRate = 0.15
                        },
                        new Discount // in future
                        {
                            DiscountId = "D4",
                            DiscountName = "Autumn Breath",
                            OrderType = "Sale",
                            ProductId = "All",
                            ProductType = "All",
                            PublicDate = new DateTime(2024, 9, 1),
                            ExpireDate = new DateTime(2024, 9, 30),
                            DiscountRate = 0.1
                        },
                        new Discount // in future
                        {
                            DiscountId = "D5",
                            DiscountName = "New Year Sale",
                            OrderType = "Sale",
                            ProductId = "All",
                            ProductType = "All",
                            PublicDate = new DateTime(2025, 1, 1),
                            ExpireDate = new DateTime(2025, 1, 31),
                            DiscountRate = 0.15
                        },
                        new Discount // expired
                        {
                            DiscountId = "D6",
                            DiscountName = "Expired Sale 1",
                            OrderType = "Sale",
                            ProductId = "All",
                            ProductType = "All",
                            PublicDate = new DateTime(2024, 1, 1),
                            ExpireDate = new DateTime(2024, 4, 30),
                            DiscountRate = 0.06
                        },
                        new Discount // expired
                        {
                            DiscountId = "D7",
                            DiscountName = "Radiant Reductions I",
                            OrderType = "Sale",
                            ProductId = "All",
                            ProductType = "All",
                            PublicDate = new DateTime(2024, 3, 1),
                            ExpireDate = new DateTime(2024, 5, 15),
                            DiscountRate = 0.09
                        },
                        new Discount // expired
                        {
                            DiscountId = "D8",
                            DiscountName = "Sparkle Savings II",
                            OrderType = "Sale",
                            ProductId = "All",
                            ProductType = "All",
                            PublicDate = new DateTime(2024, 2, 1),
                            ExpireDate = new DateTime(2024, 3, 15),
                            DiscountRate = 0.1
                        },
                        new Discount // in future
                        {
                            DiscountId = "D9",
                            DiscountName = "Radiant Reductions II",
                            OrderType = "Sale",
                            ProductId = "All",
                            ProductType = "All",
                            PublicDate = new DateTime(2024, 12, 1),
                            ExpireDate = new DateTime(2025, 1, 15),
                            DiscountRate = 0.07
                        },
                        new Discount // available
                        {
                            DiscountId = "D10",
                            DiscountName = "Sparkle Savings III",
                            OrderType = "Sale",
                            ProductId = "All",
                            ProductType = "All",
                            PublicDate = new DateTime(2024, 5, 1),
                            ExpireDate = new DateTime(2024, 12, 10),
                            DiscountRate = 0.08
                        },

                    // For one type, All ID
                        new Discount
                        {
                            DiscountId = "D11",
                            DiscountName = "Ring Gala",
                            OrderType = "Sale",
                            ProductId = "All",
                            ProductType = "Ring",
                            PublicDate = new DateTime(2024, 7, 1),
                            ExpireDate = new DateTime(2024, 7, 31),
                            DiscountRate = 0.1
                        },
                        new Discount
                        {
                            DiscountId = "D12",
                            DiscountName = "Wedding Night",
                            OrderType = "Sale",
                            ProductId = "All",
                            ProductType = "Ring",
                            PublicDate = new DateTime(2024, 6, 8),
                            ExpireDate = new DateTime(2024, 8, 31),
                            DiscountRate = 0.12
                        },
                        new Discount
                        {
                            DiscountId = "D13",
                            DiscountName = "For Your Love",
                            OrderType = "Sale",
                            ProductId = "All",
                            ProductType = "Ring",
                            PublicDate = new DateTime(2024, 6, 9),
                            ExpireDate = new DateTime(2024, 9, 30),
                            DiscountRate = 0.17
                        },
                        new Discount
                        {
                            DiscountId = "D14",
                            DiscountName = "For Your Love II",
                            OrderType = "Sale",
                            ProductId = "All",
                            ProductType = "Ring",
                            PublicDate = new DateTime(2024, 5, 10),
                            ExpireDate = new DateTime(2024, 10, 31),
                            DiscountRate = 0.24
                        },
                        new Discount
                        {
                            DiscountId = "D15",
                            DiscountName = "Wedding Night II",
                            OrderType = "Sale",
                            ProductId = "All",
                            ProductType = "Ring",
                            PublicDate = new DateTime(2024, 6, 1),
                            ExpireDate = new DateTime(2024, 11, 30),
                            DiscountRate = 0.15
                        },

                        new Discount
                        {
                            DiscountId = "D16",
                            DiscountName = "Necklace IV",
                            OrderType = "Sale",
                            ProductId = "All",
                            ProductType = "Necklace",
                            PublicDate = new DateTime(2024, 5, 1),
                            ExpireDate = new DateTime(2024, 10, 25),
                            DiscountRate = 0.18
                        },
                        new Discount
                        {
                            DiscountId = "D17",
                            DiscountName = "Necklace V",
                            OrderType = "Sale",
                            ProductId = "All",
                            ProductType = "Necklace",
                            PublicDate = new DateTime(2024, 6, 1),
                            ExpireDate = new DateTime(2024, 11, 25),
                            DiscountRate = 0.13
                        },

                    // For one type, one ID
                        new Discount
                        {
                            DiscountId = "D18",
                            DiscountName = "Necklace Special",
                            OrderType = "Sale",
                            ProductId = "P001",
                            ProductType = "Necklace",
                            PublicDate = new DateTime(2024, 6, 1),
                            ExpireDate = new DateTime(2024, 8, 25),
                            DiscountRate = 0.10
                        },
                        new Discount
                        {
                            DiscountId = "D19",
                            DiscountName = "Earrings Speical III",
                            OrderType = "Sale",
                            ProductId = "P003",
                            ProductType = "Earrings",
                            PublicDate = new DateTime(2024, 5, 1),
                            ExpireDate = new DateTime(2024, 9, 30),
                            DiscountRate = 0.07
                        },
                        new Discount
                        {
                            DiscountId = "D20",
                            DiscountName = "Earrings Speical VI",
                            OrderType = "Sale",
                            ProductId = "P009",
                            ProductType = "Earrings",
                            PublicDate = new DateTime(2024, 5, 1),
                            ExpireDate = new DateTime(2024, 8, 31),
                            DiscountRate = 0.10
                        },
                        new Discount
                        {
                            DiscountId = "D21",
                            DiscountName = "Sapphire Bracelet Discount",
                            OrderType = "Sale",
                            ProductId = "P011",
                            ProductType = "Bracelet",
                            PublicDate = new DateTime(2024, 5, 1),
                            ExpireDate = new DateTime(2024, 10, 31),
                            DiscountRate = 0.27
                        },
                        new Discount
                        {
                            DiscountId = "D22",
                            DiscountName = "Emerald Necklace Discount",
                            OrderType = "Sale",
                            ProductId = "P012",
                            ProductType = "Necklace",
                            PublicDate = new DateTime(2024, 11, 1),
                            ExpireDate = new DateTime(2024, 11, 30),
                            DiscountRate = 0.2
                        },
                        new Discount
                        {
                            DiscountId = "D23",
                            DiscountName = "Ruby Earrings Discount",
                            OrderType = "Sale",
                            ProductId = "P013",
                            ProductType = "Earrings",
                            PublicDate = new DateTime(2024, 12, 1),
                            ExpireDate = new DateTime(2024, 12, 31),
                            DiscountRate = 0.18
                        },
                        new Discount
                        {
                            DiscountId = "D24",
                            DiscountName = "Sapphire Necklace Discount",
                            OrderType = "Sale",
                            ProductId = "P014",
                            ProductType = "Necklace",
                            PublicDate = new DateTime(2024, 7, 1),
                            ExpireDate = new DateTime(2024, 7, 31),
                            DiscountRate = 0.18
                        },
                        new Discount
                        {
                            DiscountId = "D25",
                            DiscountName = "Diamond Necklace Discount",
                            OrderType = "Sale",
                            ProductId = "P015",
                            ProductType = "Necklace",
                            PublicDate = new DateTime(2024, 8, 1),
                            ExpireDate = new DateTime(2024, 8, 31),
                            DiscountRate = 0.22
                        },
                        new Discount
                        {
                            DiscountId = "D26",
                            DiscountName = "Emerald Bracelet Discount",
                            OrderType = "Sale",
                            ProductId = "P016",
                            ProductType = "Bracelet",
                            PublicDate = new DateTime(2024, 6, 1),
                            ExpireDate = new DateTime(2024, 9, 30),
                            DiscountRate = 0.21
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
                    // I1 - II1 II2 - W1 W2
                    new Warranty
                    {
                        WarrantyId = "W1",
                        ProductId = "P015",
                        ProductName = "Diamond Necklace NE-DIA044-24K",
                        StartDate = new DateTime(2024, 3, 1),
                        ExpireDate = new DateTime(2025, 9, 1) // StartDate plus ProductWarranty (18 months)
                    },
                    new Warranty
                    {
                        WarrantyId = "W2",
                        ProductId = "P021",
                        ProductName = "Diamond Earrings NE-EMA041-24K",
                        StartDate = new DateTime(2024, 3, 1),
                        ExpireDate = new DateTime(2026, 3, 1) // StartDate plus ProductWarranty (24 months)
                    },
                    // I2 - II3 II4 - W3 W4
                    new Warranty
                    {
                        WarrantyId = "W3",
                        ProductId = "P005",
                        ProductName = "Ruby Bracelet NE-RUB005-10K",
                        StartDate = new DateTime(2024, 4, 4),
                        ExpireDate = new DateTime(2025, 4, 4) // StartDate plus ProductWarranty (12 months)
                    },
                    new Warranty
                    {
                        WarrantyId = "W4",
                        ProductId = "P010",
                        ProductName = "Ruby Ring NE-RUB003-10K",
                        StartDate = new DateTime(2024, 4, 4),
                        ExpireDate = new DateTime(2025, 4, 4) // StartDate plus ProductWarranty (12 months)
                    },
                    // I3 - II5 II6 - W5 W6
                    new Warranty
                    {
                        WarrantyId = "W5",
                        ProductId = "P003",
                        ProductName = "Emerald Earrings NE-EME033-18K",
                        StartDate = new DateTime(2024, 5, 5),
                        ExpireDate = new DateTime(2026, 5, 5) // StartDate plus ProductWarranty (24 months)
                    },
                    new Warranty
                    {
                        WarrantyId = "W6",
                        ProductId = "P018",
                        ProductName = "Emerald Ring NE-EME032-18K",
                        StartDate = new DateTime(2024, 5, 5),
                        ExpireDate = new DateTime(2026, 5, 5) // StartDate plus ProductWarranty (24 months)
                    },
                    // I4 - II7 II8 II9 - W7 W8 W9
                    new Warranty
                    {
                        WarrantyId = "W7",
                        ProductId = "P011",
                        ProductName = "Sapphire Bracelet NE-SAP014-18K",
                        StartDate = new DateTime(2024, 6, 5),
                        ExpireDate = new DateTime(2025, 12, 5) // StartDate plus ProductWarranty (18 months)
                    },
                    new Warranty
                    {
                        WarrantyId = "W8",
                        ProductId = "P020",
                        ProductName = "Sapphire Earrings NE-SAP011-10K",
                        StartDate = new DateTime(2024, 6, 5),
                        ExpireDate = new DateTime(2025, 12, 5) // StartDate plus ProductWarranty (18 months)
                    },
                    new Warranty
                    {
                        WarrantyId = "W9",
                        ProductId = "P003",
                        ProductName = "Emerald Earrings NE-EME033-18K",
                        StartDate = new DateTime(2024, 6, 5),
                        ExpireDate = new DateTime(2026, 6, 5) // StartDate plus ProductWarranty (24 months)
                    },
                    // I5 - II10 II11 - W10 W11
                    new Warranty
                    {
                        WarrantyId = "W10",
                        ProductId = "P021",
                        ProductName = "Diamond Earrings NE-EMA041-24K",
                        StartDate = new DateTime(2024, 4, 5),
                        ExpireDate = new DateTime(2026, 4, 5) // StartDate plus ProductWarranty (24 months)
                    },
                    new Warranty
                    {
                        WarrantyId = "W11",
                        ProductId = "P016",
                        ProductName = "Emerald Bracelet NE-EME035-10K",
                        StartDate = new DateTime(2024, 4, 5),
                        ExpireDate = new DateTime(2025, 4, 5) // StartDate plus ProductWarranty (12 months)
                    },
                    // I6 - II12 II13 - W12 W13
                    new Warranty
                    {
                        WarrantyId = "W12",
                        ProductId = "P011",
                        ProductName = "Sapphire Bracelet NE-SAP014-18K",
                        StartDate = new DateTime(2024, 5, 3),
                        ExpireDate = new DateTime(2025, 11, 3) // StartDate plus ProductWarranty (18 months)
                    },
                    new Warranty
                    {
                        WarrantyId = "W13",
                        ProductId = "P018",
                        ProductName = "Emerald Ring NE-EME032-18K",
                        StartDate = new DateTime(2024, 5, 3),
                        ExpireDate = new DateTime(2026, 5, 3) // StartDate plus ProductWarranty (24 months)
                    },
                    // I7 - II14 II15 - W14 W15
                    new Warranty
                    {
                        WarrantyId = "W14",
                        ProductId = "P013",
                        ProductName = "Ruby Earrings NE-RUB004-14K",
                        StartDate = new DateTime(2024, 6, 5),
                        ExpireDate = new DateTime(2025, 6, 5) // StartDate plus ProductWarranty (12 months)
                    },
                    new Warranty
                    {
                        WarrantyId = "W15",
                        ProductId = "P014",
                        ProductName = "Sapphire Necklace NE-SAP015-18K",
                        StartDate = new DateTime(2024, 6, 5),
                        ExpireDate = new DateTime(2026, 6, 5) // StartDate plus ProductWarranty (24 months)
                    },
                    // I8 - II16 II17 - W16 W17
                    new Warranty
                    {
                        WarrantyId = "W16",
                        ProductId = "P015",
                        ProductName = "Diamond Necklace NE-DIA044-24K",
                        StartDate = new DateTime(2024, 3, 3),
                        ExpireDate = new DateTime(2025, 9, 3) // StartDate plus ProductWarranty (18 months)
                    },
                    new Warranty
                    {
                        WarrantyId = "W17",
                        ProductId = "P019",
                        ProductName = "Ruby Necklace NE-RUB002-14K",
                        StartDate = new DateTime(2024, 3, 3),
                        ExpireDate = new DateTime(2026, 3, 3) // StartDate plus ProductWarranty (24 months)
                    },
                    // I9 - II18 II19 - W18 W19
                    new Warranty
                    {
                        WarrantyId = "W18",
                        ProductId = "P017",
                        ProductName = "Diamond Bracelet NE-DIA045-24K",
                        StartDate = new DateTime(2024, 3, 3),
                        ExpireDate = new DateTime(2027, 3, 3) // StartDate plus ProductWarranty (36 months)
                    },
                    new Warranty
                    {
                        WarrantyId = "W19",
                        ProductId = "P012",
                        ProductName = "Emerald Necklace NE-EME031-24K",
                        StartDate = new DateTime(2024, 3, 3),
                        ExpireDate = new DateTime(2026, 3, 3) // StartDate plus ProductWarranty (24 months)
                    },
                    // I10 - II20 II21 - W20 W21
                    new Warranty
                    {
                        WarrantyId = "W20",
                        ProductId = "P011",
                        ProductName = "Sapphire Bracelet NE-SAP014-18K",

                        StartDate = new DateTime(2024, 2, 2),
                        ExpireDate = new DateTime(2025, 8, 2) // StartDate plus ProductWarranty (18 months)
                    },
                    new Warranty
                    {
                        WarrantyId = "W21",
                        ProductId = "P020",
                        ProductName = "Sapphire Earrings NE-SAP011-10K",
                        StartDate = new DateTime(2024, 2, 2),
                        ExpireDate = new DateTime(2025, 8, 2) // StartDate plus ProductWarranty (18 months)
                    },
                    // I11 - II22 II23 - W22 W23
                    new Warranty
                    {
                        WarrantyId = "W22",
                        ProductId = "P014",
                        ProductName = "Sapphire Necklace NE-SAP015-18K",
                        StartDate = new DateTime(2024, 6, 5),
                        ExpireDate = new DateTime(2026, 6, 5) // StartDate plus ProductWarranty (24 months)
                    },
                    new Warranty
                    {
                        WarrantyId = "W23",
                        ProductId = "P021",
                        ProductName = "Diamond Earrings NE-EMA041-24K",
                        StartDate = new DateTime(2024, 6, 5),
                        ExpireDate = new DateTime(2026, 6, 5) // StartDate plus ProductWarranty (24 months)
                    }
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
                entity.Property(e => e.InvoiceDate).HasColumnName("invoice_date").HasColumnType("datetime2").IsRequired();
                entity.Property(e => e.CustomerVoucher).HasColumnName("customer_voucher").HasColumnType("decimal(18, 2)").IsRequired();
                entity.Property(e => e.TotalPrice).HasColumnName("total_price").HasColumnType("decimal(18, 2)").IsRequired();
                entity.Property(e => e.EndTotalPrice).HasColumnName("end_total_price").HasColumnType("decimal(18, 2)").IsRequired();

                entity.HasData(
                    //I1 - Sale
                    new Invoice { 
                        InvoiceId = "I1", 
                        InvoiceType = "Sale", 
                        CustomerId = "C1", 
                        CustomerName = "John Doe",
                        UserId = "US3", 
                        UserFullname = "James Martinez",
                        ManagerId = "US2",
                        ManagerFullname = "Olivia Miller",
                        CashierId = "US5",
                        CashierFullname = "Theodore Garcia",
                        StallId = "ST01",
                        StallName = "Stall A",
                        InvoiceDate = new DateTime(2024, 3, 1), 
                        CustomerVoucher = 0, 
                        TotalPrice = 882348000, 
                        EndTotalPrice = 798576000,
                        InvoiceStatus = "Complete"
                    },
                    //I2 - Sale
                    new Invoice
                    {
                        InvoiceId = "I2",
                        InvoiceType = "Sale",
                        CustomerId = "C2",
                        CustomerName = "Jane Smith",
                        UserId = "US4",
                        UserFullname = "Mateo Martinez",
                        ManagerId = "US2",
                        ManagerFullname = "Olivia Miller",
                        CashierId = "US5",
                        CashierFullname = "Theodore Garcia",
                        StallId = "ST01",
                        StallName = "Stall A",
                        InvoiceDate = new DateTime(2024, 4, 4),
                        CustomerVoucher = 0,
                        TotalPrice = 240000000,
                        EndTotalPrice = 192000000,
                        InvoiceStatus = "Complete"
                    },
                    //I3 - Sale
                    new Invoice
                    {
                        InvoiceId = "I3",
                        InvoiceType = "Sale",
                        CustomerId = "C3",
                        CustomerName = "Alice Johnson",
                        UserId = "US4",
                        UserFullname = "Mateo Martinez",
                        ManagerId = "US2",
                        ManagerFullname = "Olivia Miller",
                        CashierId = "US5",
                        CashierFullname = "Theodore Garcia",
                        StallId = "ST01",
                        StallName = "Stall A",
                        InvoiceDate = new DateTime(2024, 5, 5),
                        CustomerVoucher = 1000000,
                        TotalPrice = 225000000,
                        EndTotalPrice = 209000000,
                        InvoiceStatus = "Pending"
                    },
                    //I4 - Sale
                    new Invoice
                    {
                        InvoiceId = "I4",
                        InvoiceType = "Sale",
                        CustomerId = "C5",
                        CustomerName = "Emily Wilson",
                        UserId = "US6",
                        UserFullname = "Isabel Rodriguez",
                        ManagerId = "US2",
                        ManagerFullname = "Olivia Miller",
                        CashierId = "US5",
                        CashierFullname = "Theodore Garcia",
                        StallId = "ST01",
                        StallName = "Stall A",
                        InvoiceDate = new DateTime(2024, 6, 5),
                        CustomerVoucher = 500000,
                        TotalPrice = 85000000,
                        EndTotalPrice = 84500000,
                        InvoiceStatus = "Complete"
                    },
                    //I5 - Sale
                    new Invoice
                    {
                        InvoiceId = "I5",
                        InvoiceType = "Sale",
                        CustomerId = "C2",
                        CustomerName = "Jane Smith",
                        UserId = "US7",
                        UserFullname = "Luna Taylor",
                        ManagerId = "US2",
                        ManagerFullname = "Olivia Miller",
                        CashierId = "US5",
                        CashierFullname = "Theodore Garcia",
                        StallId = "ST01",
                        StallName = "Stall A",
                        InvoiceDate = new DateTime(2024, 4, 5),
                        CustomerVoucher = 0,
                        TotalPrice = 1500000000,
                        EndTotalPrice = 1200000000,
                        InvoiceStatus = "Complete"
                    },
                    //I6 - Sale
                    new Invoice
                    {
                        InvoiceId = "I6",
                        InvoiceType = "Sale",
                        CustomerId = "C4",
                        CustomerName = "Bob Brown",
                        UserId = "US6",
                        UserFullname = "Isabel Rodriguez",
                        ManagerId = "US2",
                        ManagerFullname = "Olivia Miller",
                        CashierId = "US5",
                        CashierFullname = "Theodore Garcia",
                        StallId = "ST01",
                        StallName = "Stall A",
                        InvoiceDate = new DateTime(2024, 5, 3),
                        CustomerVoucher = 0,
                        TotalPrice = 2700000000,
                        EndTotalPrice = 2430000000,
                        InvoiceStatus = "Complete"
                    },
                    //I7 - Sale
                    new Invoice
                    {
                        InvoiceId = "I7",
                        InvoiceType = "Sale",
                        CustomerId = "C3",
                        CustomerName = "Alice Johnson",
                        UserId = "US7",
                        UserFullname = "Luna Taylor",
                        ManagerId = "US2",
                        ManagerFullname = "Olivia Miller",
                        CashierId = "US5",
                        CashierFullname = "Theodore Garcia",
                        StallId = "ST01",
                        StallName = "Stall A",
                        InvoiceDate = new DateTime(2024, 6, 5),
                        CustomerVoucher = 0,
                        TotalPrice = 960000000,
                        EndTotalPrice = 864000000,
                        InvoiceStatus = "Complete"
                    },
                    //I8 - Sale
                    new Invoice
                    {
                        InvoiceId = "I8",
                        InvoiceType = "Sale",
                        CustomerId = "C1",
                        CustomerName = "John Doe",
                        UserId = "US4",
                        UserFullname = "Mateo Martinez",
                        ManagerId = "US2",
                        ManagerFullname = "Olivia Miller",
                        CashierId = "US5",
                        CashierFullname = "Theodore Garcia",
                        StallId = "ST01",
                        StallName = "Stall A",
                        InvoiceDate = new DateTime(2024, 3, 3),
                        CustomerVoucher = 0,
                        TotalPrice = 1100000000,
                        EndTotalPrice = 990000000,
                        InvoiceStatus = "Complete"
                    },
                    //I9 - Sale
                    new Invoice
                    {
                        InvoiceId = "I9",
                        InvoiceType = "Sale",
                        CustomerId = "C3",
                        CustomerName = "Alice Johnson",
                        UserId = "US8",
                        UserFullname = "Emma Young",
                        ManagerId = "US2",
                        ManagerFullname = "Olivia Miller",
                        CashierId = "US5",
                        CashierFullname = "Theodore Garcia",
                        StallId = "ST01",
                        StallName = "Stall A",
                        InvoiceDate = new DateTime(2024, 3, 3),
                        CustomerVoucher = 0,
                        TotalPrice = 800000000,
                        EndTotalPrice = 720000000,
                        InvoiceStatus = "Complete"
                    },
                    //I10 - Sale
                    new Invoice
                    {
                        InvoiceId = "I10",
                        InvoiceType = "Sale",
                        CustomerId = "C2",
                        CustomerName = "Jane Smith",
                        UserId = "US7",
                        UserFullname = "Luna Taylor",
                        ManagerId = "US2",
                        ManagerFullname = "Olivia Miller",
                        CashierId = "US5",
                        CashierFullname = "Theodore Garcia",
                        StallId = "ST01",
                        StallName = "Stall A",
                        InvoiceDate = new DateTime(2024, 2, 2),
                        CustomerVoucher = 0,
                        TotalPrice = 2100000000,
                        EndTotalPrice = 1890000000,
                        InvoiceStatus = "Complete"
                    },
                    //I11 - Sale
                    new Invoice
                    {
                        InvoiceId = "I11",
                        InvoiceType = "Sale",
                        CustomerId = "C5",
                        CustomerName = "Emily Wilson",
                        UserId = "US4",
                        UserFullname = "Mateo Martinez",
                        ManagerId = "US2",
                        ManagerFullname = "Olivia Miller",
                        CashierId = "US5",
                        CashierFullname = "Theodore Garcia",
                        StallId = "ST01",
                        StallName = "Stall A",
                        InvoiceDate = new DateTime(2024, 6, 5),
                        CustomerVoucher = 0,
                        TotalPrice = 3000000000,
                        EndTotalPrice = 2700000000,
                        InvoiceStatus = "Complete"
                    },
                    //I12 - BUY
                    new Invoice
                    {
                        InvoiceId = "I12",
                        InvoiceType = "Buy",
                        CustomerId = "C4",
                        CustomerName = "Bob Brown",
                        UserId = "US3",
                        UserFullname = "James Martinez",
                        ManagerId = "US2",
                        ManagerFullname = "Olivia Miller",
                        CashierId = "US5",
                        CashierFullname = "Theodore Garcia",
                        StallId = "ST01",
                        StallName = "Stall A",
                        InvoiceDate = new DateTime(2024, 5, 15),
                        CustomerVoucher = 0,
                        TotalPrice = 1500000000,
                        EndTotalPrice = 1500000000,
                        InvoiceStatus = "Complete"
                    },
                    //I13 - BUY
                    new Invoice
                    {
                        InvoiceId = "I13",
                        InvoiceType = "Buy",
                        CustomerId = "C3",
                        CustomerName = "Alice Johnson",
                        UserId = "US4",
                        UserFullname = "Mateo Martinez",
                        ManagerId = "US2",
                        ManagerFullname = "Olivia Miller",
                        CashierId = "US5",
                        CashierFullname = "Theodore Garcia",
                        StallId = "ST01",
                        StallName = "Stall A",
                        InvoiceDate = new DateTime(2024, 4, 10),
                        CustomerVoucher = 0,
                        TotalPrice = 2400000000,
                        EndTotalPrice = 2400000000,
                        InvoiceStatus = "Complete"
                    },
                    //I14 - BUY
                    new Invoice
                    {
                        InvoiceId = "I14",
                        InvoiceType = "Buy",
                        CustomerId = "C5",
                        CustomerName = "Emily Wilson",
                        UserId = "US6",
                        UserFullname = "Isabel Rodriguez",
                        ManagerId = "US2",
                        ManagerFullname = "Olivia Miller",
                        CashierId = "US5",
                        CashierFullname = "Theodore Garcia",
                        StallId = "ST01",
                        StallName = "Stall A",
                        InvoiceDate = new DateTime(2024, 1, 5),
                        CustomerVoucher = 0,
                        TotalPrice = 900000000,
                        EndTotalPrice = 810000000,
                        InvoiceStatus = "Complete"
                    },
                    //I15 - BUY
                    new Invoice
                    {
                        InvoiceId = "I15",
                        InvoiceType = "Buy",
                        CustomerId = "C1",
                        CustomerName = "John Doe",
                        UserId = "US7",
                        UserFullname = "Luna Taylor",
                        ManagerId = "US2",
                        ManagerFullname = "Olivia Miller",
                        CashierId = "US5",
                        CashierFullname = "Theodore Garcia",
                        StallId = "ST01",
                        StallName = "Stall A",
                        InvoiceDate = new DateTime(2024, 2, 20),
                        CustomerVoucher = 0,
                        TotalPrice = 1200000000,
                        EndTotalPrice = 1200000000,
                        InvoiceStatus = "Complete"
                    }
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
                    // Invoice I1 - II1 II2
                    new InvoiceItem
                    {
                        InvoiceItemId = "II1",
                        InvoiceId = "I1",
                        ProductId = "P015",
                        ProductName = "Diamond Necklace",
                        Quantity = 1,
                        UnitPrice = 463488000,
                        DiscountId = "No Discount",
                        DiscountRate = 0,
                        TotalPrice = 463488000,
                        EndTotalPrice = 463488000,
                        WarrantyId = "W1",
                    },
                    new InvoiceItem
                    {
                        InvoiceItemId = "II2",
                        InvoiceId = "I1",
                        ProductId = "P021",
                        ProductName = "Diamond Earring",
                        Quantity = 1,
                        UnitPrice = 206400000,
                        DiscountId = "D1",
                        DiscountRate = 0.2,
                        TotalPrice = 206400000,
                        EndTotalPrice = 165120000,
                        WarrantyId = "W2",
                    },
                    //Invoice I2 - II3 II4
                    new InvoiceItem
                    {
                        InvoiceItemId = "II3",
                        InvoiceId = "I2",
                        ProductId = "P005",
                        ProductName = "Gold Bracelet",
                        Quantity = 1,
                        UnitPrice = 80000000,
                        DiscountId = "D3",
                        DiscountRate = 0.4,
                        TotalPrice = 80000000,
                        EndTotalPrice = 48000000,
                        WarrantyId = "W3",
                    },
                    new InvoiceItem
                    {
                        InvoiceItemId = "II4",
                        InvoiceId = "I2",
                        ProductId = "P010",
                        ProductName = "Silver Ring",
                        Quantity = 2,
                        UnitPrice = 80000000,
                        DiscountId = "D2",
                        DiscountRate = 0.3,
                        TotalPrice = 160000000,
                        EndTotalPrice = 144000000,
                        WarrantyId = "W4",
                    },
                    //Invoice I3 - II5 II6
                    new InvoiceItem
                    {
                        InvoiceItemId = "II5",
                        InvoiceId = "I3",
                        ProductId = "P003",
                        ProductName = "Platinum Necklace",
                        Quantity = 1,
                        UnitPrice = 125000000,
                        DiscountId = "D1",
                        DiscountRate = 0.2,
                        TotalPrice = 125000000,
                        EndTotalPrice = 100000000,
                        WarrantyId = "W5",
                    },
                    new InvoiceItem
                    {
                        InvoiceItemId = "II6",
                        InvoiceId = "I3",
                        ProductId = "P018",
                        ProductName = "Ruby Pendant",
                        Quantity = 1,
                        UnitPrice = 100000000,
                        DiscountId = "No Discount",
                        DiscountRate = 0,
                        TotalPrice = 100000000,
                        EndTotalPrice = 100000000,
                        WarrantyId = "W6",
                    },
                    //Invoice I4 - II7 II8 II9
                    new InvoiceItem
                    {
                        InvoiceItemId = "II7",
                        InvoiceId = "I4",
                        ProductId = "P011",
                        ProductName = "Emerald Ring",
                        Quantity = 1,
                        UnitPrice = 50000000,
                        DiscountId = "D2",
                        DiscountRate = 0.3,
                        TotalPrice = 50000000,
                        EndTotalPrice = 35000000,
                        WarrantyId = "W7",
                    },
                    new InvoiceItem
                    {
                        InvoiceItemId = "II8",
                        InvoiceId = "I4",
                        ProductId = "P020",
                        ProductName = "Sapphire Bracelet",
                        Quantity = 1,
                        UnitPrice = 35000000,
                        DiscountId = "No Discount",
                        DiscountRate = 0,
                        TotalPrice = 35000000,
                        EndTotalPrice = 35000000,
                        WarrantyId = "W8",
                    },
                    new InvoiceItem
                    {
                        InvoiceItemId = "II9",
                        InvoiceId = "I4",
                        ProductId = "P030",
                        ProductName = "Gold Earrings",
                        Quantity = 1,
                        UnitPrice = 10000000,
                        DiscountId = "D1",
                        DiscountRate = 0.2,
                        TotalPrice = 10000000,
                        EndTotalPrice = 8000000,
                        WarrantyId = "W9",
                    },
                    //Invoice I5 - II10 II11
                    new InvoiceItem
                    {
                        InvoiceItemId = "II10",
                        InvoiceId = "I5",
                        ProductId = "P021",
                        ProductName = "Diamond Earring",
                        Quantity = 2,
                        UnitPrice = 206400000,
                        DiscountId = "D2",
                        DiscountRate = 0.3,
                        TotalPrice = 412800000,
                        EndTotalPrice = 288960000,
                        WarrantyId = "W10",
                    },
                    new InvoiceItem
                    {
                        InvoiceItemId = "II11",
                        InvoiceId = "I5",
                        ProductId = "P016",
                        ProductName = "Ruby Necklace",
                        Quantity = 1,
                        UnitPrice = 800000000,
                        DiscountId = "No Discount",
                        DiscountRate = 0,
                        TotalPrice = 800000000,
                        EndTotalPrice = 800000000,
                        WarrantyId = "W11",
                    },
                    //Invoice I6 - II12 II13
                    new InvoiceItem
                    {
                        InvoiceItemId = "II12",
                        InvoiceId = "I6",
                        ProductId = "P011",
                        ProductName = "Sapphire Ring",
                        Quantity = 2,
                        UnitPrice = 900000000,
                        DiscountId = "D1",
                        DiscountRate = 0.2,
                        TotalPrice = 1800000000,
                        EndTotalPrice = 1440000000,
                        WarrantyId = "W12",
                    },
                    new InvoiceItem
                    {
                        InvoiceItemId = "II13",
                        InvoiceId = "I6",
                        ProductId = "P018",
                        ProductName = "Emerald Bracelet",
                        Quantity = 1,
                        UnitPrice = 600000000,
                        DiscountId = "No Discount",
                        DiscountRate = 0,
                        TotalPrice = 600000000,
                        EndTotalPrice = 600000000,
                        WarrantyId = "W13",
                    },
                    //Invoice I7 - II14 II15
                    new InvoiceItem
                    {
                        InvoiceItemId = "II14",
                        InvoiceId = "I7",
                        ProductId = "P013",
                        ProductName = "Opal Ring",
                        Quantity = 1,
                        UnitPrice = 480000000,
                        DiscountId = "No Discount",
                        DiscountRate = 0,
                        TotalPrice = 480000000,
                        EndTotalPrice = 480000000,
                        WarrantyId = "W14",
                    },
                    new InvoiceItem
                    {
                        InvoiceItemId = "II15",
                        InvoiceId = "I7",
                        ProductId = "P022",
                        ProductName = "Opal Earring",
                        Quantity = 2,
                        UnitPrice = 240000000,
                        DiscountId = "D3",
                        DiscountRate = 0.4,
                        TotalPrice = 480000000,
                        EndTotalPrice = 288000000,
                        WarrantyId = "W15",
                    },
                    //Invoice I8 - II16 II17
                    new InvoiceItem
                    {
                        InvoiceItemId = "II16",
                        InvoiceId = "I8",
                        ProductId = "P015",
                        ProductName = "Diamond Necklace",
                        Quantity = 1,
                        UnitPrice = 463488000,
                        DiscountId = "D4",
                        DiscountRate = 0.5,
                        TotalPrice = 463488000,
                        EndTotalPrice = 231744000,
                        WarrantyId = "W16",
                    },
                    new InvoiceItem
                    {
                        InvoiceItemId = "II17",
                        InvoiceId = "I8",
                        ProductId = "P019",
                        ProductName = "Emerald Ring",
                        Quantity = 2,
                        UnitPrice = 600000000,
                        DiscountId = "No Discount",
                        DiscountRate = 0,
                        TotalPrice = 1200000000,
                        EndTotalPrice = 1200000000,
                        WarrantyId = "W17",
                    },
                    //Invoice I9 - II18 II19
                    new InvoiceItem
                    {
                        InvoiceItemId = "II18",
                        InvoiceId = "I9",
                        ProductId = "P017",
                        ProductName = "Sapphire Necklace",
                        Quantity = 1,
                        UnitPrice = 800000000,
                        DiscountId = "D2",
                        DiscountRate = 0.3,
                        TotalPrice = 800000000,
                        EndTotalPrice = 560000000,
                        WarrantyId = "W18",
                    },
                    new InvoiceItem
                    {
                        InvoiceItemId = "II19",
                        InvoiceId = "I9",
                        ProductId = "P012",
                        ProductName = "Ruby Bracelet",
                        Quantity = 1,
                        UnitPrice = 500000000,
                        DiscountId = "No Discount",
                        DiscountRate = 0,
                        TotalPrice = 500000000,
                        EndTotalPrice = 500000000,
                        WarrantyId = "W19",
                    },
                    //Invoice I10 - II20 II21
                    new InvoiceItem
                    {
                        InvoiceItemId = "II20",
                        InvoiceId = "I10",
                        ProductId = "P011",
                        ProductName = "Sapphire Ring",
                        Quantity = 2,
                        UnitPrice = 900000000,
                        DiscountId = "D3",
                        DiscountRate = 0.4,
                        TotalPrice = 1800000000,
                        EndTotalPrice = 1080000000,
                        WarrantyId = "W20",
                    },
                    new InvoiceItem
                    {
                        InvoiceItemId = "II21",
                        InvoiceId = "I10",
                        ProductId = "P020",
                        ProductName = "Emerald Earring",
                        Quantity = 1,
                        UnitPrice = 600000000,
                        DiscountId = "No Discount",
                        DiscountRate = 0,
                        TotalPrice = 600000000,
                        EndTotalPrice = 600000000,
                        WarrantyId = "W21",
                    },
                    //Invoice I11 - II22 II23
                    new InvoiceItem
                    {
                        InvoiceItemId = "II22",
                        InvoiceId = "I11",
                        ProductId = "P014",
                        ProductName = "Turquoise Ring",
                        Quantity = 2,
                        UnitPrice = 1200000000,
                        DiscountId = "D1",
                        DiscountRate = 0.2,
                        TotalPrice = 2400000000,
                        EndTotalPrice = 1920000000,
                        WarrantyId = "W22",
                    },
                    new InvoiceItem
                    {
                        InvoiceItemId = "II23",
                        InvoiceId = "I11",
                        ProductId = "P021",
                        ProductName = "Turquoise Cabochon",
                        Quantity = 1,
                        UnitPrice = 40000000,
                        DiscountId = "No Discount",
                        DiscountRate = 0,
                        TotalPrice = 40000000,
                        EndTotalPrice = 40000000,
                        WarrantyId = "W23",
                    },
                    //Invoice I12 - II24 - BUY
                    new InvoiceItem
                    {
                        InvoiceItemId = "II24",
                        InvoiceId = "I12",
                        ProductId = "P016",
                        ProductName = "Diamond Ring",
                        Quantity = 1,
                        UnitPrice = 1500000000,
                        DiscountId = "No Discount",
                        DiscountRate = 0,
                        TotalPrice = 1500000000,
                        EndTotalPrice = 1500000000,
                        WarrantyId = "Not Applied",
                    },
                    //Invoice I13 - II26 - BUY
                    new InvoiceItem
                    {
                        InvoiceItemId = "II26",
                        InvoiceId = "I13",
                        ProductId = "P013",
                        ProductName = "Opal Necklace",
                        Quantity = 1,
                        UnitPrice = 2400000000,
                        DiscountId = "No Discount",
                        DiscountRate = 0,
                        TotalPrice = 2400000000,
                        EndTotalPrice = 2400000000,
                        WarrantyId = "Not Applied",
                    },
                    //Invoice I14 - II28 - BUY
                    new InvoiceItem
                    {
                        InvoiceItemId = "II28",
                        InvoiceId = "I14",
                        ProductId = "P011",
                        ProductName = "Sapphire Ring",
                        Quantity = 1,
                        UnitPrice = 900000000,
                        DiscountId = "No Discount",
                        DiscountRate = 0,
                        TotalPrice = 900000000,
                        EndTotalPrice = 900000000,
                        WarrantyId = "Not Applied",
                    },
                    //Invoice I15 - II29 - BUY
                    new InvoiceItem
                    {
                        InvoiceItemId = "II29",
                        InvoiceId = "I15",
                        ProductId = "P014",
                        ProductName = "Turquoise Ring",
                        Quantity = 1,
                        UnitPrice = 1200000000,
                        DiscountId = "No Discount",
                        DiscountRate = 0,
                        TotalPrice = 1200000000,
                        EndTotalPrice = 1200000000,
                        WarrantyId = "Not Applied",
                    }
                );
            });

            modelBuilder.Entity<Stall>(entity =>
            {
                entity.HasData(
                    new Stall
                    {
                        StallId = "ST01",
                        UserId = "US2",
                        StaffName = "Olivia Miller",
                        StallDescription = "Opening",
                        StallName = "Stall A",
                        StallType = "Ring"
                    },
                    new Stall
                    {
                        StallId = "ST02",
                        UserId = "US2",
                        StaffName = "Olivia Miller",
                        StallDescription = "Opening",
                        StallName = "Stall B",
                        StallType = "Bracelet"
                    },
                    new Stall
                    {
                        StallId = "ST03",
                        UserId = "US2",
                        StaffName = "Olivia Miller",
                        StallDescription = "Opening",
                        StallName = "Stall C",
                        StallType = "Necklace"
                    },
                    new Stall
                    {
                        StallId = "ST04",
                        UserId = "US2",
                        StaffName = "Olivia Miller",
                        StallDescription = "Opening",
                        StallName = "Stall D",
                        StallType = "Earring"
                    },
                    new Stall
                    {
                        StallId = "ST05",
                        UserId = "US2",
                        StaffName = "Olivia Miller",
                        StallDescription = "Maintenance",
                        StallName = "Stall E",
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

            modelBuilder.Entity<StallEmployee>(entity => 
            {
                entity.HasData(
                    // Stall A, US3 US7 US9 US18
                    new StallEmployee { 
                        StallId = "ST01",
                        StallName = "Stall A",
                        EmployeeId = "US3",
                        EmployeeFullname = "James Martinez",
                        Role = "Sale"
                    },
                    new StallEmployee
                    {
                        StallId = "ST01",
                        StallName = "Stall A",
                        EmployeeId = "US7",
                        EmployeeFullname = "Luna Taylor",
                        Role = "Sale"
                    },
                    new StallEmployee
                    {
                        StallId = "ST01",
                        StallName = "Stall A",
                        EmployeeId = "US9",
                        EmployeeFullname = "Ava Davis",
                        Role = "Cashier"
                    },
                    new StallEmployee
                    {
                        StallId = "ST01",
                        StallName = "Stall A",
                        EmployeeId = "US18",
                        EmployeeFullname = "Avery Lewis",
                        Role = "Sale"
                    },
                    // Stall B, US13 US10 US8 US15 US16
                    new StallEmployee
                    {
                        StallId = "ST02",
                        StallName = "Stall B",
                        EmployeeId = "US13",
                        EmployeeFullname = "Mia Anderson",
                        Role = "Sale"
                    },
                    new StallEmployee
                    {
                        StallId = "ST02",
                        StallName = "Stall B",
                        EmployeeId = "US10",
                        EmployeeFullname = "Sophia Wilson",
                        Role = "Cashier"
                    },
                    new StallEmployee
                    {
                        StallId = "ST02",
                        StallName = "Stall B",
                        EmployeeId = "US8",
                        EmployeeFullname = "Emma Young",
                        Role = "Sale"
                    },
                    new StallEmployee
                    {
                        StallId = "ST02",
                        StallName = "Stall B",
                        EmployeeId = "US15",
                        EmployeeFullname = "Evelyn White",
                        Role = "Sale"
                    },
                    new StallEmployee
                    {
                        StallId = "ST02",
                        StallName = "Stall B",
                        EmployeeId = "US16",
                        EmployeeFullname = "Abigail Harris",
                        Role = "Sale"
                    },
                    // Stall C, US4 US11 US17
                    new StallEmployee
                    {
                        StallId = "ST03",
                        StallName = "Stall C",
                        EmployeeId = "US4",
                        EmployeeFullname = "Mateo Martinez",
                        Role = "Sale"
                    },
                    new StallEmployee
                    {
                        StallId = "ST03",
                        StallName = "Stall C",
                        EmployeeId = "US11",
                        EmployeeFullname = "Charlotte Brown",
                        Role = "Cashier"
                    },
                    new StallEmployee
                    {
                        StallId = "ST03",
                        StallName = "Stall C",
                        EmployeeId = "US17",
                        EmployeeFullname = "Ella Clark",
                        Role = "Sale"
                    },
                    // Stall D, US14 US5
                    new StallEmployee
                    {
                        StallId = "ST04",
                        StallName = "Stall D",
                        EmployeeId = "US14",
                        EmployeeFullname = "Harper Thomas",
                        Role = "Sale"
                    },
                    new StallEmployee
                    {
                        StallId = "ST04",
                        StallName = "Stall D",
                        EmployeeId = "US5",
                        EmployeeFullname = "Theodore Garcia",
                        Role = "Cashier"
                    },
                    // Stall E, US6 US12
                    new StallEmployee
                    {
                        StallId = "ST05",
                        StallName = "Stall E",
                        EmployeeId = "US6",
                        EmployeeFullname = "Isabel Rodriguez",
                        Role = "Sale"
                    },
                    new StallEmployee
                    {
                        StallId = "ST05",
                        StallName = "Stall E",
                        EmployeeId = "US12",
                        EmployeeFullname = "Amelia Jones",
                        Role = "Cashier"
                    }

                    );
            });
        }
    }
}
