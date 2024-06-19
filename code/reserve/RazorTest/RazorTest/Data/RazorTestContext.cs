using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorTest.Models;

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
        public DbSet<Gem> Gem { get; set; } = default!;
        public DbSet<Customer> Customer { get; set; } = default!;
        public DbSet<Invoice> Invoice { get; set; } = default!;
        public DbSet<InvoiceItem> InvoiceItem { get; set; } = default!;
        public DbSet<Warranty> Warranty { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
    }
}
