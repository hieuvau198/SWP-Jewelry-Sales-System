using JewelSystemBE.Model;
using Microsoft.EntityFrameworkCore;

namespace JewelSystemBE.Data
{
    public class JewelDbContext : DbContext
    {
        public JewelDbContext(DbContextOptions options) : base(options)
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
                entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8392858FD");

                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasMaxLength(255);
                entity.Property(e => e.CustomerName).HasMaxLength(255);
                entity.Property(e => e.CustomerPhone).HasMaxLength(255);
                entity.Property(e => e.CustomerRank).HasMaxLength(255);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasKey(e => e.DiscountId).HasName("PK__Discount__E43F6D96C504D961");

                entity.ToTable("Discount");

                entity.Property(e => e.DiscountId).HasMaxLength(255);
                entity.Property(e => e.DiscountName).HasMaxLength(255);
                entity.Property(e => e.DiscountRate).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.OrderType).HasMaxLength(255);
                entity.Property(e => e.ProductId).HasMaxLength(255);
                entity.Property(e => e.ProductType).HasMaxLength(255);

            
            });

            modelBuilder.Entity<Gem>(entity =>
            {
                entity.HasKey(e => e.GemId).HasName("PK__Gem__F101D580389FC71F");

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
                entity.HasKey(e => e.GoldId).HasName("PK__Gold__5CD52C539175CF56");

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
                entity.HasKey(e => e.InvoiceId).HasName("PK__Invoice__D796AAB5753A75EE");

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

         
            });

            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.HasKey(e => e.InvoiceItemId).HasName("PK__InvoiceI__478FE09C077364AE");

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

         
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CD12FC6754");

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
                entity.Property(e => e.ProductQuantity).HasColumnType("INT NOT NULL");
                entity.Property(e => e.ProductWarranty).HasColumnType("INT NOT NULL");
                entity.Property(e => e.CreatedAt).HasColumnType("DATE NOT NULL,");

            });

            modelBuilder.Entity<Stall>(entity =>
            {
                entity.HasKey(e => e.StallId).HasName("PK__Stall__A9EDB1A802FA0314");

                entity.ToTable("Stall");

                entity.Property(e => e.StallId).HasMaxLength(255);
                entity.Property(e => e.StaffName).HasMaxLength(255);
                entity.Property(e => e.StallDescription).HasMaxLength(255);
                entity.Property(e => e.StallName).HasMaxLength(255);
                entity.Property(e => e.StallType).HasMaxLength(255);
                entity.Property(e => e.UserId).HasMaxLength(255);

            });

            modelBuilder.Entity<StallEmployee>(entity =>
            {
                entity.HasKey(e => e.StallEmployeeId).HasName("PK__StallEmp__A5C2F78ADDDAF018");

                entity.ToTable("StallEmployee");

                entity.Property(e => e.StallEmployeeId).HasMaxLength(255);
                entity.Property(e => e.EmployeeFullname).HasMaxLength(255);
                entity.Property(e => e.EmployeeId).HasMaxLength(255);
                entity.Property(e => e.Role).HasMaxLength(50);
                entity.Property(e => e.StallId).HasMaxLength(255);
                entity.Property(e => e.StallName).HasMaxLength(255);

            });

            modelBuilder.Entity<StallItem>(entity =>
            {
                entity.HasKey(e => e.StallItemId).HasName("PK__StallIte__F36E51DA8840A0C3");

                entity.ToTable("StallItem");

                entity.Property(e => e.StallItemId).HasMaxLength(255);
                entity.Property(e => e.ProductId).HasMaxLength(255);
                entity.Property(e => e.ProductName).HasMaxLength(255);
                entity.Property(e => e.StallId).HasMaxLength(255);

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4CDBA1EC41");

                entity.ToTable("User");

                entity.Property(e => e.UserId).HasMaxLength(255);
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.Fullname).HasMaxLength(255);
                entity.Property(e => e.Password).HasMaxLength(255);
                entity.Property(e => e.Role).HasMaxLength(255);
                entity.Property(e => e.Username).HasMaxLength(255);
            });

            modelBuilder.Entity<Warranty>(entity =>
            {
                entity.HasKey(e => e.WarrantyId).HasName("PK__Warranty__2ED31813C0EDCFFF");

                entity.ToTable("Warranty");

                entity.Property(e => e.WarrantyId).HasMaxLength(255);
                entity.Property(e => e.ProductId).HasMaxLength(255);
                entity.Property(e => e.ProductName).HasMaxLength(255);
            });

        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        // latest ends



        /*
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            

            modelBuilder.Entity<User>(builder =>
            {
                builder.HasData(
                    new User { UserId = "US01", Username = "user1", Password = BCrypt.Net.BCrypt.HashPassword("password1"), Fullname = "Liam Williams", Email = "liam@gmail.com", Role = "Admin" },
                    new User { UserId = "US02", Username = "user2", Password = BCrypt.Net.BCrypt.HashPassword("password2"), Fullname = "Olivia Miller", Email = "olivia@gmail.com", Role = "Admin" },
                    new User { UserId = "US03", Username = "user3", Password = BCrypt.Net.BCrypt.HashPassword("password3"), Fullname = "James Martinez", Email = "james@gmail.com", Role = "Manager" },
                    new User { UserId = "US04", Username = "user4", Password = BCrypt.Net.BCrypt.HashPassword("password4"), Fullname = "Mateo Martinez", Email = "matao@gmail.com", Role = "Manager" },
                    new User { UserId = "US05", Username = "user5", Password = BCrypt.Net.BCrypt.HashPassword("password5"), Fullname = "Theodore Garcia", Email = "theodore@gmail.com", Role = "Manager" },
                    new User { UserId = "US06", Username = "user6", Password = BCrypt.Net.BCrypt.HashPassword("password6"), Fullname = "Isabel Rodriguez", Email = "isabel@gmail.com", Role = "Manager" },
                    new User { UserId = "US07", Username = "user7", Password = BCrypt.Net.BCrypt.HashPassword("password7"), Fullname = "Luna Taylor", Email = "luna@gmail.com", Role = "Cashier" },
                    new User { UserId = "US08", Username = "user8", Password = BCrypt.Net.BCrypt.HashPassword("password8"), Fullname = "Emma Young", Email = "emma@gmail.com", Role = "Sale" },
                    new User { UserId = "US09", Username = "user9", Password = BCrypt.Net.BCrypt.HashPassword("password9"), Fullname = "Ava Davis", Email = "ava@gmail.com", Role = "Sale" },
                    new User { UserId = "US10", Username = "user10", Password = BCrypt.Net.BCrypt.HashPassword("password10"), Fullname = "Sophia Wilson", Email = "sophia@gmail.com", Role = "Sale" },
                    new User { UserId = "US11", Username = "user11", Password = BCrypt.Net.BCrypt.HashPassword("password11"), Fullname = "Charlotte Brown", Email = "charlotte@gmail.com", Role = "Cashier" },
                    new User { UserId = "US12", Username = "user12", Password = BCrypt.Net.BCrypt.HashPassword("password12"), Fullname = "Amelia Jones", Email = "amelia@gmail.com", Role = "Sale" },
                    new User { UserId = "US13", Username = "user13", Password = BCrypt.Net.BCrypt.HashPassword("password13"), Fullname = "Mia Anderson", Email = "mia@gmail.com", Role = "Sale" },
                    new User { UserId = "US14", Username = "user14", Password = BCrypt.Net.BCrypt.HashPassword("password14"), Fullname = "Harper Thomas", Email = "harper@gmail.com", Role = "Sale" },
                    new User { UserId = "US15", Username = "user15", Password = BCrypt.Net.BCrypt.HashPassword("password15"), Fullname = "Evelyn White", Email = "evelyn@gmail.com", Role = "Cashier" },
                    new User { UserId = "US16", Username = "user16", Password = BCrypt.Net.BCrypt.HashPassword("password16"), Fullname = "Abigail Harris", Email = "abigail@gmail.com", Role = "Sale" },
                    new User { UserId = "US17", Username = "user17", Password = BCrypt.Net.BCrypt.HashPassword("password17"), Fullname = "Ella Clark", Email = "ella@gmail.com", Role = "Sale" },
                    new User { UserId = "US18", Username = "user18", Password = BCrypt.Net.BCrypt.HashPassword("password18"), Fullname = "Avery Lewis", Email = "avery@gmail.com", Role = "Sale" },
                    new User { UserId = "US19", Username = "user19", Password = BCrypt.Net.BCrypt.HashPassword("password17"), Fullname = "Julius Caesar", Email = "julius@gmail.com", Role = "Cashier" },
                    new User { UserId = "US20", Username = "user20", Password = BCrypt.Net.BCrypt.HashPassword("password17"), Fullname = "Charles De Quin", Email = "charles@gmail.com", Role = "Sale" },
                    new User { UserId = "US21", Username = "user21", Password = BCrypt.Net.BCrypt.HashPassword("password17"), Fullname = "Victoria Sylvanas", Email = "sylvanas@gmail.com", Role = "Sale" },
                    new User { UserId = "US22", Username = "user22", Password = BCrypt.Net.BCrypt.HashPassword("password17"), Fullname = "Albert Brown", Email = "albert@gmail.com", Role = "Sale" }
                );
            });

            modelBuilder.Entity<Jewel>(builder =>
            {
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
                entity.HasData(
                    new Gold { GoldId = "vang24k", GoldName = "24K", GoldCode = "Vàng nữ trang 99,99%" },
                    new Gold { GoldId = "vang18k", GoldName = "18K", GoldCode = "Vàng nữ trang 75%" },
                    new Gold { GoldId = "vang14k", GoldName = "14K", GoldCode = "Vàng nữ trang 58,3%" },
                    new Gold { GoldId = "vang10k", GoldName = "10K", GoldCode = "Vàng nữ trang 41,7%" }
                );
            });

            modelBuilder.Entity<Product>(entity =>
            {
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
                },
                new Product
                {
                    ProductId = "P062",
                    ProductCode = "997655504675",
                    ProductName = "Colombian Emerald Necklace",
                    ProductImages = "P062.png",
                    ProductQuantity = 22,
                    ProductType = "Necklace",
                    ProductWeight = 6.2762189716804055,
                    ProductWarranty = 13,
                    MarkupRate = 2.652651600048639,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 2.183326837547216,
                    GemId = "GE031",
                    GemName = "Colombian Emerald",
                    GemWeight = 1.2,
                    LaborCost = 22541225.68969354,
                    CreatedAt = new DateTime(2024, 1, 26)
                }, new Product
                {
                    ProductId = "P063",
                    ProductCode = "132820434702",
                    ProductName = "Colombian Emerald Bracelet",
                    ProductImages = "P063.png",
                    ProductQuantity = 24,
                    ProductType = "Bracelet",
                    ProductWeight = 9.374758169106602,
                    ProductWarranty = 14,
                    MarkupRate = 1.478320046919129,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 7.869087365479009,
                    GemId = "GE031",
                    GemName = "Colombian Emerald",
                    GemWeight = 1.2,
                    LaborCost = 4803614.988950649,
                    CreatedAt = new DateTime(2024, 1, 14)
                }, new Product
                {
                    ProductId = "P064",
                    ProductCode = "223652976341",
                    ProductName = "Russian Emerald Necklace",
                    ProductImages = "P064.png",
                    ProductQuantity = 14,
                    ProductType = "Necklace",
                    ProductWeight = 5.391583388597187,
                    ProductWarranty = 27,
                    MarkupRate = 2.964831574866391,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 1.9503276588997664,
                    GemId = "GE035",
                    GemName = "Russian Emerald",
                    GemWeight = 1.5,
                    LaborCost = 11322111.7437102,
                    CreatedAt = new DateTime(2024, 1, 2)
                }, new Product
                {
                    ProductId = "P065",
                    ProductCode = "134535776319",
                    ProductName = "Opal Cabochon Bracelet",
                    ProductImages = "P065.png",
                    ProductQuantity = 14,
                    ProductType = "Bracelet",
                    ProductWeight = 9.748344844997362,
                    ProductWarranty = 47,
                    MarkupRate = 2.0854551419359146,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 7.332863876943767,
                    GemId = "GE022",
                    GemName = "Opal Cabochon",
                    GemWeight = 2.1,
                    LaborCost = 48052995.22584672,
                    CreatedAt = new DateTime(2024, 1, 2)
                }, new Product
                {
                    ProductId = "P066",
                    ProductCode = "282821916462",
                    ProductName = "Cat's Eye Chrysoberyl Cabochon Earrings",
                    ProductImages = "P066.png",
                    ProductQuantity = 15,
                    ProductType = "Earrings",
                    ProductWeight = 12.495811598649325,
                    ProductWarranty = 32,
                    MarkupRate = 1.056134513136873,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 8.088059724182148,
                    GemId = "GE026",
                    GemName = "Cat's Eye Chrysoberyl Cabochon",
                    GemWeight = 2.5,
                    LaborCost = 4178216.465776931,
                    CreatedAt = new DateTime(2024, 1, 20)
                }, new Product
                {
                    ProductId = "P067",
                    ProductCode = "736198789615",
                    ProductName = "Lapis Lazuli Cabochon Ring",
                    ProductImages = "P067.png",
                    ProductQuantity = 5,
                    ProductType = "Ring",
                    ProductWeight = 10.94677041286857,
                    ProductWarranty = 16,
                    MarkupRate = 2.1148330811040097,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 3.2511990910559962,
                    GemId = "GE028",
                    GemName = "Lapis Lazuli Cabochon",
                    GemWeight = 7.5,
                    LaborCost = 45521277.52513677,
                    CreatedAt = new DateTime(2024, 1, 11)
                }, new Product
                {
                    ProductId = "P068",
                    ProductCode = "652141365560",
                    ProductName = "Thai Sapphire Earrings",
                    ProductImages = "P068.png",
                    ProductQuantity = 23,
                    ProductType = "Earrings",
                    ProductWeight = 13.64288688257303,
                    ProductWarranty = 42,
                    MarkupRate = 1.4553703825497204,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 9.01602052808841,
                    GemId = "GE017",
                    GemName = "Thai Sapphire",
                    GemWeight = 1.8,
                    LaborCost = 49663585.42700095,
                    CreatedAt = new DateTime(2024, 1, 24)
                }, new Product
                {
                    ProductId = "P069",
                    ProductCode = "869018111056",
                    ProductName = "Colombian Emerald Ring",
                    ProductImages = "P069.png",
                    ProductQuantity = 20,
                    ProductType = "Ring",
                    ProductWeight = 9.395539666938141,
                    ProductWarranty = 23,
                    MarkupRate = 2.0070032319070266,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 7.002071749330647,
                    GemId = "GE031",
                    GemName = "Colombian Emerald",
                    GemWeight = 1.2,
                    LaborCost = 2958963.6531875115,
                    CreatedAt = new DateTime(2024, 1, 15)
                }, new Product
                {
                    ProductId = "P070",
                    ProductCode = "360314486545",
                    ProductName = "Natural Ceylon Sapphire Bracelet",
                    ProductImages = "P070.png",
                    ProductQuantity = 12,
                    ProductType = "Bracelet",
                    ProductWeight = 5.19393168455606,
                    ProductWarranty = 14,
                    MarkupRate = 2.147434124505918,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 2.779067976106182,
                    GemId = "GE011",
                    GemName = "Natural Ceylon Sapphire",
                    GemWeight = 1.02,
                    LaborCost = 13212584.193749525,
                    CreatedAt = new DateTime(2024, 1, 17)
                }, new Product
                {
                    ProductId = "P071",
                    ProductCode = "973237878653",
                    ProductName = "Lapis Lazuli Cabochon Earrings",
                    ProductImages = "P071.png",
                    ProductQuantity = 17,
                    ProductType = "Earrings",
                    ProductWeight = 12.861498155646276,
                    ProductWarranty = 32,
                    MarkupRate = 1.5106439551370094,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 4.7503978016786474,
                    GemId = "GE028",
                    GemName = "Lapis Lazuli Cabochon",
                    GemWeight = 7.5,
                    LaborCost = 35179269.036827415,
                    CreatedAt = new DateTime(2024, 1, 9)
                }, new Product
                {
                    ProductId = "P072",
                    ProductCode = "416465740045",
                    ProductName = "Natural Mozambique Ruby Necklace",
                    ProductImages = "P072.png",
                    ProductQuantity = 13,
                    ProductType = "Necklace",
                    ProductWeight = 8.893963593410232,
                    ProductWarranty = 28,
                    MarkupRate = 1.4292663110662522,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 5.604617931143634,
                    GemId = "GE001",
                    GemName = "Natural Mozambique Ruby",
                    GemWeight = 0.98,
                    LaborCost = 7925490.264503677,
                    CreatedAt = new DateTime(2024, 1, 29)
                }, new Product
                {
                    ProductId = "P073",
                    ProductCode = "905642139964",
                    ProductName = "Afghan Emerald Necklace",
                    ProductImages = "P073.png",
                    ProductQuantity = 20,
                    ProductType = "Necklace",
                    ProductWeight = 8.725656224659257,
                    ProductWarranty = 43,
                    MarkupRate = 1.72498826916746,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 5.71210348004109,
                    GemId = "GE034",
                    GemName = "Afghan Emerald",
                    GemWeight = 2.2,
                    LaborCost = 28689999.243368484,
                    CreatedAt = new DateTime(2024, 1, 12)
                }, new Product
                {
                    ProductId = "P074",
                    ProductCode = "518675440124",
                    ProductName = "Colombian Emerald Ring",
                    ProductImages = "P074.png",
                    ProductQuantity = 5,
                    ProductType = "Ring",
                    ProductWeight = 11.11573663631463,
                    ProductWarranty = 20,
                    MarkupRate = 1.026264339277348,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 7.801767096749241,
                    GemId = "GE031",
                    GemName = "Colombian Emerald",
                    GemWeight = 1.2,
                    LaborCost = 33418437.65172168,
                    CreatedAt = new DateTime(2024, 1, 2)
                }, new Product
                {
                    ProductId = "P075",
                    ProductCode = "883107591713",
                    ProductName = "Jade Cabochon Earrings",
                    ProductImages = "P075.png",
                    ProductQuantity = 7,
                    ProductType = "Earrings",
                    ProductWeight = 17.32709664325859,
                    ProductWarranty = 38,
                    MarkupRate = 2.7746569220624755,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 9.510534211910212,
                    GemId = "GE027",
                    GemName = "Jade Cabochon",
                    GemWeight = 6.8,
                    LaborCost = 19873671.94199773,
                    CreatedAt = new DateTime(2024, 1, 10)
                }, new Product
                {
                    ProductId = "P076",
                    ProductCode = "285490561092",
                    ProductName = "Jade Cabochon Necklace",
                    ProductImages = "P076.png",
                    ProductQuantity = 13,
                    ProductType = "Necklace",
                    ProductWeight = 12.189626989427303,
                    ProductWarranty = 27,
                    MarkupRate = 1.711876058221355,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 5.085055313771572,
                    GemId = "GE027",
                    GemName = "Jade Cabochon",
                    GemWeight = 6.8,
                    LaborCost = 16554494.02060713,
                    CreatedAt = new DateTime(2024, 1, 22)
                }, new Product
                {
                    ProductId = "P077",
                    ProductCode = "810850684545",
                    ProductName = "Heated Natural Ruby Necklace",
                    ProductImages = "P077.png",
                    ProductQuantity = 10,
                    ProductType = "Necklace",
                    ProductWeight = 6.061633953917166,
                    ProductWarranty = 30,
                    MarkupRate = 2.5867224320072006,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 4.822001831915394,
                    GemId = "GE006",
                    GemName = "Heated Natural Ruby",
                    GemWeight = 0.34,
                    LaborCost = 9726902.597013839,
                    CreatedAt = new DateTime(2024, 1, 7)
                }, new Product
                {
                    ProductId = "P078",
                    ProductCode = "123256896894",
                    ProductName = "Heated Natural Sapphire Necklace",
                    ProductImages = "P078.png",
                    ProductQuantity = 12,
                    ProductType = "Necklace",
                    ProductWeight = 11.121893409395742,
                    ProductWarranty = 31,
                    MarkupRate = 1.5921443127414832,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 8.368142414864934,
                    GemId = "GE016",
                    GemName = "Heated Natural Sapphire",
                    GemWeight = 2.1,
                    LaborCost = 40912458.290988036,
                    CreatedAt = new DateTime(2024, 1, 11)
                }, new Product
                {
                    ProductId = "P079",
                    ProductCode = "387439802850",
                    ProductName = "Ethiopian Sapphire Necklace",
                    ProductImages = "P079.png",
                    ProductQuantity = 13,
                    ProductType = "Necklace",
                    ProductWeight = 10.061922050371816,
                    ProductWarranty = 12,
                    MarkupRate = 1.001408411053442,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 6.05603485898372,
                    GemId = "GE019",
                    GemName = "Ethiopian Sapphire",
                    GemWeight = 1.3,
                    LaborCost = 4194023.0041391337,
                    CreatedAt = new DateTime(2024, 1, 15)
                }, new Product
                {
                    ProductId = "P080",
                    ProductCode = "255717953045",
                    ProductName = "Mozambique Ruby Bracelet",
                    ProductImages = "P080.png",
                    ProductQuantity = 9,
                    ProductType = "Bracelet",
                    ProductWeight = 1.8268978794962705,
                    ProductWarranty = 21,
                    MarkupRate = 1.1317351319358644,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 1.470998773475916,
                    GemId = "GE005",
                    GemName = "Mozambique Ruby",
                    GemWeight = 0.33,
                    LaborCost = 10721397.801540006,
                    CreatedAt = new DateTime(2024, 1, 16)
                }, new Product
                {
                    ProductId = "P081",
                    ProductCode = "739592453907",
                    ProductName = "Colombian Emerald Bracelet",
                    ProductImages = "P081.png",
                    ProductQuantity = 14,
                    ProductType = "Bracelet",
                    ProductWeight = 8.345755921584324,
                    ProductWarranty = 38,
                    MarkupRate = 1.5788510456637512,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 6.1122190563446885,
                    GemId = "GE038",
                    GemName = "Colombian Emerald",
                    GemWeight = 0.9,
                    LaborCost = 45645441.27693173,
                    CreatedAt = new DateTime(2024, 1, 6)
                }, new Product
                {
                    ProductId = "P082",
                    ProductCode = "554417345981",
                    ProductName = "Mozambique Ruby (Heated) Bracelet",
                    ProductImages = "P082.png",
                    ProductQuantity = 17,
                    ProductType = "Bracelet",
                    ProductWeight = 9.854161962718672,
                    ProductWarranty = 33,
                    MarkupRate = 2.1139432088655075,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 8.36858555621919,
                    GemId = "GE008",
                    GemName = "Mozambique Ruby (Heated)",
                    GemWeight = 0.49,
                    LaborCost = 14180127.36439872,
                    CreatedAt = new DateTime(2024, 1, 3)
                }, new Product
                {
                    ProductId = "P083",
                    ProductCode = "378892611670",
                    ProductName = "Australian Sapphire Necklace",
                    ProductImages = "P083.png",
                    ProductQuantity = 22,
                    ProductType = "Necklace",
                    ProductWeight = 7.288483721512957,
                    ProductWarranty = 18,
                    MarkupRate = 2.343028127426095,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 1.8754761710121342,
                    GemId = "GE014",
                    GemName = "Australian Sapphire",
                    GemWeight = 3.2,
                    LaborCost = 31622697.745569754,
                    CreatedAt = new DateTime(2024, 1, 22)
                }, new Product
                {
                    ProductId = "P084",
                    ProductCode = "895541535083",
                    ProductName = "Moonstone Cabochon Ring",
                    ProductImages = "P084.png",
                    ProductQuantity = 17,
                    ProductType = "Ring",
                    ProductWeight = 14.23106067517639,
                    ProductWarranty = 37,
                    MarkupRate = 1.0399685928834637,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 9.36234952428152,
                    GemId = "GE021",
                    GemName = "Moonstone Cabochon",
                    GemWeight = 3.5,
                    LaborCost = 16563472.75871514,
                    CreatedAt = new DateTime(2024, 1, 17)
                }, new Product
                {
                    ProductId = "P085",
                    ProductCode = "683840289612",
                    ProductName = "Brazilian Emerald Necklace",
                    ProductImages = "P085.png",
                    ProductQuantity = 10,
                    ProductType = "Necklace",
                    ProductWeight = 11.310927651708962,
                    ProductWarranty = 22,
                    MarkupRate = 2.1938325138235886,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 7.884157029854667,
                    GemId = "GE033",
                    GemName = "Brazilian Emerald",
                    GemWeight = 1.8,
                    LaborCost = 27675466.14092264,
                    CreatedAt = new DateTime(2024, 1, 2)
                }, new Product
                {
                    ProductId = "P086",
                    ProductCode = "855506970606",
                    ProductName = "Zambian Emerald Ring",
                    ProductImages = "P086.png",
                    ProductQuantity = 8,
                    ProductType = "Ring",
                    ProductWeight = 8.003112078575315,
                    ProductWarranty = 15,
                    MarkupRate = 1.6851489741219896,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 2.748266650560025,
                    GemId = "GE032",
                    GemName = "Zambian Emerald",
                    GemWeight = 2.5,
                    LaborCost = 15154325.736343848,
                    CreatedAt = new DateTime(2024, 1, 26)
                }, new Product
                {
                    ProductId = "P087",
                    ProductCode = "698883680113",
                    ProductName = "Russian Emerald Ring",
                    ProductImages = "P087.png",
                    ProductQuantity = 24,
                    ProductType = "Ring",
                    ProductWeight = 4.961104588767682,
                    ProductWarranty = 33,
                    MarkupRate = 1.928251193971454,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 1.485363881132936,
                    GemId = "GE035",
                    GemName = "Russian Emerald",
                    GemWeight = 1.5,
                    LaborCost = 42822876.531945735,
                    CreatedAt = new DateTime(2024, 1, 20)
                }, new Product
                {
                    ProductId = "P088",
                    ProductCode = "537897479809",
                    ProductName = "Star Sapphire Cabochon Necklace",
                    ProductImages = "P088.png",
                    ProductQuantity = 16,
                    ProductType = "Necklace",
                    ProductWeight = 8.161774897988959,
                    ProductWarranty = 17,
                    MarkupRate = 2.2545791946922975,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 2.2413237529785395,
                    GemId = "GE025",
                    GemName = "Star Sapphire Cabochon",
                    GemWeight = 3.2,
                    LaborCost = 3063576.5542223216,
                    CreatedAt = new DateTime(2024, 1, 22)
                }, new Product
                {
                    ProductId = "P089",
                    ProductCode = "157125451128",
                    ProductName = "Mozambique Ruby Necklace",
                    ProductImages = "P089.png",
                    ProductQuantity = 11,
                    ProductType = "Necklace",
                    ProductWeight = 7.708358513529792,
                    ProductWarranty = 14,
                    MarkupRate = 2.833644193886045,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 4.517302371067512,
                    GemId = "GE005",
                    GemName = "Mozambique Ruby",
                    GemWeight = 0.33,
                    LaborCost = 20354729.05482548,
                    CreatedAt = new DateTime(2024, 1, 12)
                }, new Product
                {
                    ProductId = "P090",
                    ProductCode = "300830776654",
                    ProductName = "Asscher Cut Diamond Necklace",
                    ProductImages = "P090.png",
                    ProductQuantity = 24,
                    ProductType = "Necklace",
                    ProductWeight = 6.310055060479454,
                    ProductWarranty = 38,
                    MarkupRate = 1.5813632694189736,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 2.068965854016282,
                    GemId = "GE046",
                    GemName = "Asscher Cut Diamond",
                    GemWeight = 1.3,
                    LaborCost = 25064114.060412843,
                    CreatedAt = new DateTime(2024, 1, 17)
                }, new Product
                {
                    ProductId = "P091",
                    ProductCode = "773834750665",
                    ProductName = "Opal Cabochon Bracelet",
                    ProductImages = "P091.png",
                    ProductQuantity = 7,
                    ProductType = "Bracelet",
                    ProductWeight = 5.2230354313027005,
                    ProductWarranty = 20,
                    MarkupRate = 2.2396282540551438,
                    GoldId = "vang10k",
                    GoldName = "10K",
                    GoldWeight = 2.3224759493616145,
                    GemId = "GE022",
                    GemName = "Opal Cabochon",
                    GemWeight = 2.1,
                    LaborCost = 34825371.4555608,
                    CreatedAt = new DateTime(2024, 1, 9)
                }, new Product
                {
                    ProductId = "P092",
                    ProductCode = "298516339018",
                    ProductName = "Mozambique Ruby Ring",
                    ProductImages = "P092.png",
                    ProductQuantity = 9,
                    ProductType = "Ring",
                    ProductWeight = 5.69410048424049,
                    ProductWarranty = 27,
                    MarkupRate = 2.382340498189611,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 3.5622533490032104,
                    GemId = "GE009",
                    GemName = "Mozambique Ruby",
                    GemWeight = 0.49,
                    LaborCost = 8578941.791058734,
                    CreatedAt = new DateTime(2024, 1, 6)
                }, new Product
                {
                    ProductId = "P093",
                    ProductCode = "792674934158",
                    ProductName = "Ethiopian Emerald Bracelet",
                    ProductImages = "P093.png",
                    ProductQuantity = 5,
                    ProductType = "Bracelet",
                    ProductWeight = 5.423469781387585,
                    ProductWarranty = 35,
                    MarkupRate = 1.273107963338799,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 2.6806493651067336,
                    GemId = "GE040",
                    GemName = "Ethiopian Emerald",
                    GemWeight = 1.3,
                    LaborCost = 42270085.5229617,
                    CreatedAt = new DateTime(2024, 1, 10)
                }, new Product
                {
                    ProductId = "P094",
                    ProductCode = "775223714850",
                    ProductName = "Oval Diamond Bracelet",
                    ProductImages = "P094.png",
                    ProductQuantity = 10,
                    ProductType = "Bracelet",
                    ProductWeight = 12.530601570954346,
                    ProductWarranty = 33,
                    MarkupRate = 1.7553388224754771,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 9.225380724081996,
                    GemId = "GE044",
                    GemName = "Oval Diamond",
                    GemWeight = 1.2,
                    LaborCost = 38039309.39858325,
                    CreatedAt = new DateTime(2024, 1, 18)
                }, new Product
                {
                    ProductId = "P095",
                    ProductCode = "289398842985",
                    ProductName = "Garnet Cabochon Ring",
                    ProductImages = "P095.png",
                    ProductQuantity = 20,
                    ProductType = "Ring",
                    ProductWeight = 7.959672484924197,
                    ProductWarranty = 38,
                    MarkupRate = 2.0936609871436485,
                    GoldId = "vang24k",
                    GoldName = "24K",
                    GoldWeight = 4.244471648116274,
                    GemId = "GE030",
                    GemName = "Garnet Cabochon",
                    GemWeight = 3,
                    LaborCost = 43984746.533329844,
                    CreatedAt = new DateTime(2024, 1, 7)
                }, new Product
                {
                    ProductId = "P096",
                    ProductCode = "346196169746",
                    ProductName = "Moonstone Cabochon Bracelet",
                    ProductImages = "P096.png",
                    ProductQuantity = 24,
                    ProductType = "Bracelet",
                    ProductWeight = 9.614713701385215,
                    ProductWarranty = 12,
                    MarkupRate = 2.0783819312115486,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 4.538769638974723,
                    GemId = "GE021",
                    GemName = "Moonstone Cabochon",
                    GemWeight = 3.5,
                    LaborCost = 34699113.981977336,
                    CreatedAt = new DateTime(2024, 1, 25)
                }, new Product
                {
                    ProductId = "P097",
                    ProductCode = "729722262028",
                    ProductName = "Garnet Cabochon Necklace",
                    ProductImages = "P097.png",
                    ProductQuantity = 7,
                    ProductType = "Necklace",
                    ProductWeight = 5.4744477214319165,
                    ProductWarranty = 22,
                    MarkupRate = 2.0305332291768714,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 1.8079704872461873,
                    GemId = "GE030",
                    GemName = "Garnet Cabochon",
                    GemWeight = 3,
                    LaborCost = 6343166.36201734,
                    CreatedAt = new DateTime(2024, 1, 22)
                }, new Product
                {
                    ProductId = "P098",
                    ProductCode = "894208493653",
                    ProductName = "Colombian Emerald Bracelet",
                    ProductImages = "P098.png",
                    ProductQuantity = 22,
                    ProductType = "Bracelet",
                    ProductWeight = 11.881774016516705,
                    ProductWarranty = 18,
                    MarkupRate = 2.5880326005739667,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 9.598053351540303,
                    GemId = "GE038",
                    GemName = "Colombian Emerald",
                    GemWeight = 0.9,
                    LaborCost = 35858379.55481039,
                    CreatedAt = new DateTime(2024, 1, 22)
                }, new Product
                {
                    ProductId = "P099",
                    ProductCode = "975718722237",
                    ProductName = "Lapis Lazuli Cabochon Ring",
                    ProductImages = "P099.png",
                    ProductQuantity = 22,
                    ProductType = "Ring",
                    ProductWeight = 17.00563510539713,
                    ProductWarranty = 45,
                    MarkupRate = 2.200319913866552,
                    GoldId = "vang18k",
                    GoldName = "18K",
                    GoldWeight = 8.899555324292471,
                    GemId = "GE028",
                    GemName = "Lapis Lazuli Cabochon",
                    GemWeight = 7.5,
                    LaborCost = 18372770.988842566,
                    CreatedAt = new DateTime(2024, 1, 2)
                }, new Product
                {
                    ProductId = "P100",
                    ProductCode = "186329661165",
                    ProductName = "Mozambique Ruby Earrings",
                    ProductImages = "P100.png",
                    ProductQuantity = 6,
                    ProductType = "Earrings",
                    ProductWeight = 1.8772857207332527,
                    ProductWarranty = 29,
                    MarkupRate = 1.6931379646437632,
                    GoldId = "vang14k",
                    GoldName = "14K",
                    GoldWeight = 1.087642746564586,
                    GemId = "GE007",
                    GemName = "Mozambique Ruby",
                    GemWeight = 0.36,
                    LaborCost = 26908960.946195457,
                    CreatedAt = new DateTime(2024, 1, 17)
                }
                );

            });

            modelBuilder.Entity<Discount>(entity =>
            {
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
                        StallName = "Sky Treasure",
                        StallType = "Diversity"
                    },
                    new Stall
                    {
                        StallId = "ST02",
                        UserId = "US2",
                        StaffName = "Olivia Miller",
                        StallDescription = "Opening",
                        StallName = "Delights",
                        StallType = "Diversity"
                    },
                    new Stall
                    {
                        StallId = "ST03",
                        UserId = "US2",
                        StaffName = "Olivia Miller",
                        StallDescription = "Opening",
                        StallName = "The Vintage",
                        StallType = "Diversity"
                    },
                    new Stall
                    {
                        StallId = "ST04",
                        UserId = "US2",
                        StaffName = "Olivia Miller",
                        StallDescription = "Maintenance",
                        StallName = "The Charm",
                        StallType = "Diversity"
                    }
                    );
            });
                
            modelBuilder.Entity<StallItem>(entity =>
            {
                entity.HasData(
                    new StallItem
                    {
                        StallItemId = "SI001",
                        StallId = "ST01",
                        ProductId = "P001",
                        ProductName = "Ruby Necklace NE-R1-24K",
                        quantity = 10,
                    }, new StallItem
                    {
                        StallItemId = "SI002",
                        StallId = "ST01",
                        ProductId = "P002",
                        ProductName = "Sapphire Necklace NE-S2-14K",
                        quantity = 15,
                    }, new StallItem
                    {
                        StallItemId = "SI003",
                        StallId = "ST01",
                        ProductId = "P003",
                        ProductName = "Emerald Earrings NE-EME033-18K",
                        quantity = 25,
                    }, new StallItem
                    {
                        StallItemId = "SI004",
                        StallId = "ST01",
                        ProductId = "P004",
                        ProductName = "Diamond Ring NE-DIA041-24K",
                        quantity = 30,
                    }, new StallItem
                    {
                        StallItemId = "SI005",
                        StallId = "ST01",
                        ProductId = "P005",
                        ProductName = "Ruby Bracelet NE-RUB005-10K",
                        quantity = 20,
                    }, new StallItem
                    {
                        StallItemId = "SI006",
                        StallId = "ST01",
                        ProductId = "P006",
                        ProductName = "Diamond Necklace NE-EMA046-24K",
                        quantity = 10,
                    }, new StallItem
                    {
                        StallItemId = "SI007",
                        StallId = "ST01",
                        ProductId = "P007",
                        ProductName = "Sapphire Ring NE-SAP013-24K",
                        quantity = 12,
                    }, new StallItem
                    {
                        StallItemId = "SI008",
                        StallId = "ST01",
                        ProductId = "P008",
                        ProductName = "Emerald Necklace NE-EME034-14K",
                        quantity = 20,
                    }, new StallItem
                    {
                        StallItemId = "SI009",
                        StallId = "ST01",
                        ProductId = "P009",
                        ProductName = "Diamond Earrings NE-DIA043-24K",
                        quantity = 18,
                    }, new StallItem
                    {
                        StallItemId = "SI0010",
                        StallId = "ST01",
                        ProductId = "P010",
                        ProductName = "Ruby Ring NE-RUB003-10K",
                        quantity = 15,
                    }, new StallItem
                    {
                        StallItemId = "SI011",
                        StallId = "ST01",
                        ProductId = "P100",
                        ProductName = "Mozambique Ruby Earrings",
                        quantity = 6,
                    }, new StallItem
                    {
                        StallItemId = "SI012",
                        StallId = "ST01",
                        ProductId = "P011",
                        ProductName = "Sapphire Bracelet NE-SAP014-18K",
                        quantity = 22,
                    }, new StallItem
                    {
                        StallItemId = "SI013",
                        StallId = "ST01",
                        ProductId = "P012",
                        ProductName = "Emerald Necklace NE-EME031-24K",
                        quantity = 10,
                    }, new StallItem
                    {
                        StallItemId = "SI014",
                        StallId = "ST01",
                        ProductId = "P013",
                        ProductName = "Ruby Earrings NE-RUB004-14K",
                        quantity = 14,
                    }, new StallItem
                    {
                        StallItemId = "SI015",
                        StallId = "ST01",
                        ProductId = "P014",
                        ProductName = "Sapphire Necklace NE-SAP015-18K",
                        quantity = 8,
                    }, new StallItem
                    {
                        StallItemId = "SI016",
                        StallId = "ST01",
                        ProductId = "P015",
                        ProductName = "Diamond Necklace NE-DIA044-24K",
                        quantity = 16,
                    }, new StallItem
                    {
                        StallItemId = "SI017",
                        StallId = "ST01",
                        ProductId = "P016",
                        ProductName = "Emerald Bracelet NE-EME035-10K",
                        quantity = 18,
                    }, new StallItem
                    {
                        StallItemId = "SI018",
                        StallId = "ST01",
                        ProductId = "P017",
                        ProductName = "Diamond Bracelet NE-DIA045-24K",
                        quantity = 12,
                    }, new StallItem
                    {
                        StallItemId = "SI019",
                        StallId = "ST01",
                        ProductId = "P018",
                        ProductName = "Emerald Ring NE-EME032-18K",
                        quantity = 15,
                    }, new StallItem
                    {
                        StallItemId = "SI020",
                        StallId = "ST01",
                        ProductId = "P019",
                        ProductName = "Ruby Necklace NE-RUB002-14K",
                        quantity = 10,
                    }, new StallItem
                    {
                        StallItemId = "SI021",
                        StallId = "ST01",
                        ProductId = "P020",
                        ProductName = "Sapphire Earrings NE-SAP011-10K",
                        quantity = 20,
                    }, new StallItem
                    {
                        StallItemId = "SI022",
                        StallId = "ST01",
                        ProductId = "P021",
                        ProductName = "Diamond Earrings NE-EMA041-24K",
                        quantity = 18,
                    }, new StallItem
                    {
                        StallItemId = "SI023",
                        StallId = "ST01",
                        ProductId = "P022",
                        ProductName = "Pear Shaped Diamond Earrings",
                        quantity = 12,
                    }, new StallItem
                    {
                        StallItemId = "SI024",
                        StallId = "ST01",
                        ProductId = "P023",
                        ProductName = "Russian Emerald Ring",
                        quantity = 15,
                    }, new StallItem
                    {
                        StallItemId = "SI025",
                        StallId = "ST01",
                        ProductId = "P024",
                        ProductName = "Natural Ceylon Sapphire Earrings",
                        quantity = 16,
                    }, new StallItem
                    {
                        StallItemId = "SI026",
                        StallId = "ST02",
                        ProductId = "P025",
                        ProductName = "Princess Cut Diamond Bracelet",
                        quantity = 14,
                    }, new StallItem
                    {
                        StallItemId = "SI027",
                        StallId = "ST02",
                        ProductId = "P026",
                        ProductName = "Radiant Cut Diamond Earrings",
                        quantity = 16,
                    }, new StallItem
                    {
                        StallItemId = "SI028",
                        StallId = "ST02",
                        ProductId = "P027",
                        ProductName = "Colombian Emerald Earrings",
                        quantity = 13,
                    }, new StallItem
                    {
                        StallItemId = "SI029",
                        StallId = "ST02",
                        ProductId = "P028",
                        ProductName = "Padparadscha Sapphire Ring",
                        quantity = 7,
                    }, new StallItem
                    {
                        StallItemId = "SI030",
                        StallId = "ST02",
                        ProductId = "P029",
                        ProductName = "Garnet Cabochon Necklace",
                        quantity = 14,
                    }, new StallItem
                    {
                        StallItemId = "SI031",
                        StallId = "ST02",
                        ProductId = "P030",
                        ProductName = "Brazilian Emerald Necklace",
                        quantity = 12,
                    }, new StallItem
                    {
                        StallItemId = "SI032",
                        StallId = "ST02",
                        ProductId = "P031",
                        ProductName = "Synthetic Emerald Bracelet",
                        quantity = 12,
                    }, new StallItem
                    {
                        StallItemId = "SI033",
                        StallId = "ST02",
                        ProductId = "P032",
                        ProductName = "Pear Shaped Diamond Ring",
                        quantity = 22,
                    }, new StallItem
                    {
                        StallItemId = "SI034",
                        StallId = "ST02",
                        ProductId = "P033",
                        ProductName = "Brazilian Emerald Ring",
                        quantity = 21,
                    }, new StallItem
                    {
                        StallItemId = "SI035",
                        StallId = "ST02",
                        ProductId = "P034",
                        ProductName = "Radiant Cut Diamond Bracelet",
                        quantity = 8,
                    }, new StallItem
                    {
                        StallItemId = "SI036",
                        StallId = "ST02",
                        ProductId = "P035",
                        ProductName = "Oval Diamond Necklace",
                        quantity = 16,
                    }, new StallItem
                    {
                        StallItemId = "SI037",
                        StallId = "ST02",
                        ProductId = "P036",
                        ProductName = "Brazilian Emerald Bracelet",
                        quantity = 18,
                    }, new StallItem
                    {
                        StallItemId = "SI038",
                        StallId = "ST02",
                        ProductId = "P037",
                        ProductName = "Moonstone Cabochon Bracelet",
                        quantity = 13,
                    }, new StallItem
                    {
                        StallItemId = "SI039",
                        StallId = "ST02",
                        ProductId = "P038",
                        ProductName = "Thai Sapphire Necklace",
                        quantity = 23,
                    }, new StallItem
                    {
                        StallItemId = "SI040",
                        StallId = "ST02",
                        ProductId = "P039",
                        ProductName = "Heated Natural Ruby Ring",
                        quantity = 24,
                    }, new StallItem
                    {
                        StallItemId = "SI041",
                        StallId = "ST02",
                        ProductId = "P040",
                        ProductName = "Natural Ceylon Sapphire Bracelet",
                        quantity = 18,
                    }, new StallItem
                    {
                        StallItemId = "SI042",
                        StallId = "ST02",
                        ProductId = "P041",
                        ProductName = "Opal Cabochon Bracelet",
                        quantity = 12,
                    }, new StallItem
                    {
                        StallItemId = "SI043",
                        StallId = "ST02",
                        ProductId = "P042",
                        ProductName = "Brazilian Emerald Earrings",
                        quantity = 21,
                    }, new StallItem
                    {
                        StallItemId = "SI044",
                        StallId = "ST02",
                        ProductId = "P043",
                        ProductName = "Natural Ceylon Sapphire Bracelet",
                        quantity = 10,
                    }, new StallItem
                    {
                        StallItemId = "SI045",
                        StallId = "ST02",
                        ProductId = "P044",
                        ProductName = "Round Brilliant Diamond Necklace",
                        quantity = 11,
                    }, new StallItem
                    {
                        StallItemId = "SI046",
                        StallId = "ST02",
                        ProductId = "P045",
                        ProductName = "Colombian Emerald Ring",
                        quantity = 7,
                    }, new StallItem
                    {
                        StallItemId = "SI047",
                        StallId = "ST02",
                        ProductId = "P046",
                        ProductName = "Garnet Cabochon Ring",
                        quantity = 6,
                    }, new StallItem
                    {
                        StallItemId = "SI048",
                        StallId = "ST02",
                        ProductId = "P047",
                        ProductName = "Madagascar Sapphire Bracelet",
                        quantity = 18,
                    }, new StallItem
                    {
                        StallItemId = "SI049",
                        StallId = "ST02",
                        ProductId = "P048",
                        ProductName = "India Ruby Necklace",
                        quantity = 17,
                    }, new StallItem
                    {
                        StallItemId = "SI050",
                        StallId = "ST02",
                        ProductId = "P049",
                        ProductName = "Ethiopian Sapphire Bracelet",
                        quantity = 9,
                    }, new StallItem
                    {
                        StallItemId = "SI051",
                        StallId = "ST03",
                        ProductId = "P050",
                        ProductName = "Australian Sapphire Ring",
                        quantity = 10,
                    }, new StallItem
                    {
                        StallItemId = "SI052",
                        StallId = "ST03",
                        ProductId = "P051",
                        ProductName = "Heart Shaped Diamond Necklace",
                        quantity = 12,
                    }, new StallItem
                    {
                        StallItemId = "SI053",
                        StallId = "ST03",
                        ProductId = "P052",
                        ProductName = "Round Brilliant Diamond Earrings",
                        quantity = 20,
                    }, new StallItem
                    {
                        StallItemId = "SI054",
                        StallId = "ST03",
                        ProductId = "P053",
                        ProductName = "Emerald Cut Diamond Ring",
                        quantity = 10,
                    }, new StallItem
                    {
                        StallItemId = "SI055",
                        StallId = "ST03",
                        ProductId = "P054",
                        ProductName = "Moonstone Cabochon Earrings",
                        quantity = 8,
                    }, new StallItem
                    {
                        StallItemId = "SI056",
                        StallId = "ST03",
                        ProductId = "P055",
                        ProductName = "Montana Sapphire Necklace",
                        quantity = 12,
                    }, new StallItem
                    {
                        StallItemId = "SI057",
                        StallId = "ST03",
                        ProductId = "P056",
                        ProductName = "Oval Diamond Ring",
                        quantity = 11,
                    }, new StallItem
                    {
                        StallItemId = "SI058",
                        StallId = "ST03",
                        ProductId = "P057",
                        ProductName = "Ethiopian Emerald Bracelet",
                        quantity = 22,
                    }, new StallItem
                    {
                        StallItemId = "SI059",
                        StallId = "ST03",
                        ProductId = "P058",
                        ProductName = "Australian Sapphire Earrings",
                        quantity = 12,
                    }, new StallItem
                    {
                        StallItemId = "SI060",
                        StallId = "ST03",
                        ProductId = "P059",
                        ProductName = "Labradorite Cabochon Bracelet",
                        quantity = 10,
                    }, new StallItem
                    {
                        StallItemId = "SI061",
                        StallId = "ST03",
                        ProductId = "P060",
                        ProductName = "Pear Shaped Diamond Necklace",
                        quantity = 11,
                    }, new StallItem
                    {
                        StallItemId = "SI062",
                        StallId = "ST03",
                        ProductId = "P061",
                        ProductName = "Natural Mozambique Ruby Ring",
                        quantity = 23,
                    }, new StallItem
                    {
                        StallItemId = "SI063",
                        StallId = "ST03",
                        ProductId = "P062",
                        ProductName = "Colombian Emerald Necklace",
                        quantity = 22,
                    }, new StallItem
                    {
                        StallItemId = "SI064",
                        StallId = "ST03",
                        ProductId = "P063",
                        ProductName = "Colombian Emerald Bracelet",
                        quantity = 24,
                    }, new StallItem
                    {
                        StallItemId = "SI065",
                        StallId = "ST03",
                        ProductId = "P064",
                        ProductName = "Russian Emerald Necklace",
                        quantity = 14,
                    }, new StallItem
                    {
                        StallItemId = "SI066",
                        StallId = "ST03",
                        ProductId = "P065",
                        ProductName = "Opal Cabochon Bracelet",
                        quantity = 14,
                    }, new StallItem
                    {
                        StallItemId = "SI067",
                        StallId = "ST03",
                        ProductId = "P066",
                        ProductName = "Cat's Eye Chrysoberyl Cabochon Earrings",
                        quantity = 15,
                    }, new StallItem
                    {
                        StallItemId = "SI068",
                        StallId = "ST03",
                        ProductId = "P067",
                        ProductName = "Lapis Lazuli Cabochon Ring",
                        quantity = 5,
                    }, new StallItem
                    {
                        StallItemId = "SI069",
                        StallId = "ST03",
                        ProductId = "P068",
                        ProductName = "Thai Sapphire Earrings",
                        quantity = 23,
                    }, new StallItem
                    {
                        StallItemId = "SI070",
                        StallId = "ST03",
                        ProductId = "P069",
                        ProductName = "Colombian Emerald Ring",
                        quantity = 20,
                    }, new StallItem
                    {
                        StallItemId = "SI071",
                        StallId = "ST03",
                        ProductId = "P070",
                        ProductName = "Natural Ceylon Sapphire Bracelet",
                        quantity = 12,
                    }, new StallItem
                    {
                        StallItemId = "SI072",
                        StallId = "ST03",
                        ProductId = "P071",
                        ProductName = "Lapis Lazuli Cabochon Earrings",
                        quantity = 17,
                    }, new StallItem
                    {
                        StallItemId = "SI073",
                        StallId = "ST03",
                        ProductId = "P072",
                        ProductName = "Natural Mozambique Ruby Necklace",
                        quantity = 13,
                    }, new StallItem
                    {
                        StallItemId = "SI074",
                        StallId = "ST03",
                        ProductId = "P073",
                        ProductName = "Afghan Emerald Necklace",
                        quantity = 20,
                    }, new StallItem
                    {
                        StallItemId = "SI075",
                        StallId = "ST03",
                        ProductId = "P074",
                        ProductName = "Colombian Emerald Ring",
                        quantity = 5,
                    }, new StallItem
                    {
                        StallItemId = "SI076",
                        StallId = "ST04",
                        ProductId = "P075",
                        ProductName = "Jade Cabochon Earrings",
                        quantity = 7,
                    }, new StallItem
                    {
                        StallItemId = "SI077",
                        StallId = "ST04",
                        ProductId = "P076",
                        ProductName = "Jade Cabochon Necklace",
                        quantity = 13,
                    }, new StallItem
                    {
                        StallItemId = "SI078",
                        StallId = "ST04",
                        ProductId = "P077",
                        ProductName = "Heated Natural Ruby Necklace",
                        quantity = 10,
                    }, new StallItem
                    {
                        StallItemId = "SI079",
                        StallId = "ST04",
                        ProductId = "P078",
                        ProductName = "Heated Natural Sapphire Necklace",
                        quantity = 12,
                    }, new StallItem
                    {
                        StallItemId = "SI080",
                        StallId = "ST04",
                        ProductId = "P079",
                        ProductName = "Ethiopian Sapphire Necklace",
                        quantity = 13,
                    }, new StallItem
                    {
                        StallItemId = "SI081",
                        StallId = "ST04",
                        ProductId = "P080",
                        ProductName = "Mozambique Ruby Bracelet",
                        quantity = 9,
                    }, new StallItem
                    {
                        StallItemId = "SI082",
                        StallId = "ST04",
                        ProductId = "P081",
                        ProductName = "Colombian Emerald Bracelet",
                        quantity = 14,
                    }, new StallItem
                    {
                        StallItemId = "SI083",
                        StallId = "ST04",
                        ProductId = "P082",
                        ProductName = "Mozambique Ruby (Heated) Bracelet",
                        quantity = 17,
                    }, new StallItem
                    {
                        StallItemId = "SI084",
                        StallId = "ST04",
                        ProductId = "P083",
                        ProductName = "Australian Sapphire Necklace",
                        quantity = 22,
                    }, new StallItem
                    {
                        StallItemId = "SI085",
                        StallId = "ST04",
                        ProductId = "P084",
                        ProductName = "Moonstone Cabochon Ring",
                        quantity = 17,
                    }, new StallItem
                    {
                        StallItemId = "SI086",
                        StallId = "ST04",
                        ProductId = "P085",
                        ProductName = "Brazilian Emerald Necklace",
                        quantity = 10,
                    }, new StallItem
                    {
                        StallItemId = "SI087",
                        StallId = "ST04",
                        ProductId = "P086",
                        ProductName = "Zambian Emerald Ring",
                        quantity = 8,
                    }, new StallItem
                    {
                        StallItemId = "SI088",
                        StallId = "ST04",
                        ProductId = "P087",
                        ProductName = "Russian Emerald Ring",
                        quantity = 24,
                    }, new StallItem
                    {
                        StallItemId = "SI089",
                        StallId = "ST04",
                        ProductId = "P088",
                        ProductName = "Star Sapphire Cabochon Necklace",
                        quantity = 16,
                    }, new StallItem
                    {
                        StallItemId = "SI090",
                        StallId = "ST04",
                        ProductId = "P089",
                        ProductName = "Mozambique Ruby Necklace",
                        quantity = 11,
                    }, new StallItem
                    {
                        StallItemId = "SI091",
                        StallId = "ST04",
                        ProductId = "P090",
                        ProductName = "Asscher Cut Diamond Necklace",
                        quantity = 24,
                    }, new StallItem
                    {
                        StallItemId = "SI092",
                        StallId = "ST04",
                        ProductId = "P091",
                        ProductName = "Opal Cabochon Bracelet",
                        quantity = 7,
                    }, new StallItem
                    {
                        StallItemId = "SI093",
                        StallId = "ST04",
                        ProductId = "P092",
                        ProductName = "Mozambique Ruby Ring",
                        quantity = 9,
                    }, new StallItem
                    {
                        StallItemId = "SI094",
                        StallId = "ST04",
                        ProductId = "P093",
                        ProductName = "Ethiopian Emerald Bracelet",
                        quantity = 5,
                    }, new StallItem
                    {
                        StallItemId = "SI095",
                        StallId = "ST04",
                        ProductId = "P094",
                        ProductName = "Oval Diamond Bracelet",
                        quantity = 10,
                    }, new StallItem
                    {
                        StallItemId = "SI096",
                        StallId = "ST04",
                        ProductId = "P095",
                        ProductName = "Garnet Cabochon Ring",
                        quantity = 20,
                    }, new StallItem
                    {
                        StallItemId = "SI097",
                        StallId = "ST04",
                        ProductId = "P096",
                        ProductName = "Moonstone Cabochon Bracelet",
                        quantity = 24,
                    }, new StallItem
                    {
                        StallItemId = "SI098",
                        StallId = "ST04",
                        ProductId = "P097",
                        ProductName = "Garnet Cabochon Necklace",
                        quantity = 7,
                    }, new StallItem
                    {
                        StallItemId = "SI099",
                        StallId = "ST04",
                        ProductId = "P098",
                        ProductName = "Colombian Emerald Bracelet",
                        quantity = 22,
                    }, new StallItem
                    {
                        StallItemId = "SI100",
                        StallId = "ST04",
                        ProductId = "P099",
                        ProductName = "Lapis Lazuli Cabochon Ring",
                        quantity = 22,
                    }
                );
            });

            modelBuilder.Entity<StallEmployee>(entity => 
            {
                entity.HasData(
                    new StallEmployee
                    {
                        StallEmployeeId = "SE007",
                        StallId = "ST01",
                        StallName = "Sky Treasure",
                        EmployeeId = "US07",
                        EmployeeFullname = "Luna Taylor",
                        Role = "Cashier",
                    }, new StallEmployee
                    {
                        StallEmployeeId = "SE008",
                        StallId = "ST01",
                        StallName = "Sky Treasure",
                        EmployeeId = "US08",
                        EmployeeFullname = "Emma Young",
                        Role = "Sale",
                    }, new StallEmployee
                    {
                        StallEmployeeId = "SE009",
                        StallId = "ST01",
                        StallName = "Sky Treasure",
                        EmployeeId = "US09",
                        EmployeeFullname = "Ava Davis",
                        Role = "Sale",
                    }, new StallEmployee
                    {
                        StallEmployeeId = "SE0010",
                        StallId = "ST01",
                        StallName = "Sky Treasure",
                        EmployeeId = "US10",
                        EmployeeFullname = "Sophia Wilson",
                        Role = "Sale",
                    }, new StallEmployee
                    {
                        StallEmployeeId = "SE011",
                        StallId = "ST02",
                        StallName = "Delights",
                        EmployeeId = "US11",
                        EmployeeFullname = "Charlotte Brown",
                        Role = "Cashier",
                    }, new StallEmployee
                    {
                        StallEmployeeId = "SE012",
                        StallId = "ST02",
                        StallName = "Delights",
                        EmployeeId = "US12",
                        EmployeeFullname = "Amelia Jones",
                        Role = "Sale",
                    }, new StallEmployee
                    {
                        StallEmployeeId = "SE013",
                        StallId = "ST02",
                        StallName = "Delights",
                        EmployeeId = "US13",
                        EmployeeFullname = "Mia Anderson",
                        Role = "Sale",
                    }, new StallEmployee
                    {
                        StallEmployeeId = "SE014",
                        StallId = "ST02",
                        StallName = "Delights",
                        EmployeeId = "US14",
                        EmployeeFullname = "Harper Thomas",
                        Role = "Sale",
                    }, new StallEmployee
                    {
                        StallEmployeeId = "SE015",
                        StallId = "ST03",
                        StallName = "The Vintage",
                        EmployeeId = "US15",
                        EmployeeFullname = "Evelyn White",
                        Role = "Cashier",
                    }, new StallEmployee
                    {
                        StallEmployeeId = "SE016",
                        StallId = "ST03",
                        StallName = "The Vintage",
                        EmployeeId = "US16",
                        EmployeeFullname = "Abigail Harris",
                        Role = "Sale",
                    }, new StallEmployee
                    {
                        StallEmployeeId = "SE017",
                        StallId = "ST03",
                        StallName = "The Vintage",
                        EmployeeId = "US17",
                        EmployeeFullname = "Ella Clark",
                        Role = "Sale",
                    }, new StallEmployee
                    {
                        StallEmployeeId = "SE018",
                        StallId = "ST03",
                        StallName = "The Vintage",
                        EmployeeId = "US18",
                        EmployeeFullname = "Avery Lewis",
                        Role = "Sale",
                    }, new StallEmployee
                    {
                        StallEmployeeId = "SE019",
                        StallId = "ST04",
                        StallName = "The Charm",
                        EmployeeId = "US19",
                        EmployeeFullname = "Julius Caesar",
                        Role = "Cashier",
                    }, new StallEmployee
                    {
                        StallEmployeeId = "SE020",
                        StallId = "ST04",
                        StallName = "The Charm",
                        EmployeeId = "US20",
                        EmployeeFullname = "Charles De Quin",
                        Role = "Sale",
                    }, new StallEmployee
                    {
                        StallEmployeeId = "SE021",
                        StallId = "ST04",
                        StallName = "The Charm",
                        EmployeeId = "US21",
                        EmployeeFullname = "Victoria Sylvanas",
                        Role = "Sale",
                    }, new StallEmployee
                    {
                        StallEmployeeId = "SE022",
                        StallId = "ST04",
                        StallName = "The Charm",
                        EmployeeId = "US22",
                        EmployeeFullname = "Albert Brown",
                        Role = "Sale",
                    }

                    );
            });
        }

         */

    }
}
