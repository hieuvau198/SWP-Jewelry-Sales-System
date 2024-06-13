using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorTest.Models;
using JewelBO;

namespace RazorTest.Data
{
    public class RazorTestContext : DbContext
    {
        public RazorTestContext (DbContextOptions<RazorTestContext> options)
            : base(options)
        {
        }

        public DbSet<RazorTest.Models.Discount> Discount { get; set; } = default!;

        internal async Task CreateDiscountAsync(Discount discount)
        {
            throw new NotImplementedException();
        }
        public DbSet<RazorTest.Models.Gem> Gem { get; set; } = default!;
        public DbSet<RazorTest.Models.Customer> Customer { get; set; } = default!;
        public DbSet<RazorTest.Models.Invoice> Invoice { get; set; } = default!;
        public DbSet<RazorTest.Models.InvoiceItem> InvoiceItem { get; set; } = default!;
        public DbSet<JewelBO.Warranty> Warranty { get; set; } = default!;
        public DbSet<JewelBO.User> User { get; set; } = default!;
    }
}
