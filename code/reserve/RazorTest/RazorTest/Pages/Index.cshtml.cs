using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages
{
    public class IndexModel : PageModel
    {
        public const string SessionKeyAuthState = "_AuthState";
        public const string SessionKeyUserObject = "_UserObject";

        private readonly ApiService _apiService;
        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Discount> Discounts { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Gem> Gems { get; set; }
        public List<Gold> Golds { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
        public List<Jewel> Jewels { get; set; }
        public List<Product> Products { get; set; }
        public PaginatedList<Product> PaginatedProducts { get; set; } // Đối tượng phân trang
        public List<User> Users { get; set; }
        public List<Warranty> Warranties { get; set; }
        public List<Login> Logins { get; set; }
        public List<GoldPrice> GoldPrices { get; set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            Discounts = await _apiService.GetAsync<List<Discount>>("http://localhost:5071/api/discount");
            Customers = await _apiService.GetAsync<List<Customer>>("http://localhost:5071/api/customer");
            Gems = await _apiService.GetAsync<List<Gem>>("http://localhost:5071/api/gem");
            Golds = await _apiService.GetAsync<List<Gold>>("http://localhost:5071/api/gold");
            Invoices = await _apiService.GetAsync<List<Invoice>>("http://localhost:5071/api/invoice");
            InvoiceItems = await _apiService.GetAsync<List<InvoiceItem>>("http://localhost:5071/api/invoiceitem");

            const int pageSize = 9; // Number of products per page
            Products = await _apiService.GetAsync<List<Product>>("http://localhost:5071/api/product");
            if (Products != null)
            {
                Products = Products.OrderBy(p => p.ProductCode).ToList();
                PaginatedProducts = PaginatedList<Product>.Create(Products.AsQueryable(), pageIndex ?? 1, pageSize);
            }
            Users = await _apiService.GetAsync<List<User>>("http://localhost:5071/api/user");
            Warranties = await _apiService.GetAsync<List<Warranty>>("http://localhost:5071/api/warranty");

            // Commented out to prevent errors if APIs are not available
            // GoldPrices = await _apiService.GetAsync<List<GoldPrice>>("http://localhost:5071/api/goldprice");
            // Logins = await _apiService.GetAsync<List<Login>>("http://localhost:5071/api/auth/login");

            if (Discounts != null) Discounts = Discounts.OrderBy(d => d.DiscountId).ToList();
            if (Customers != null) Customers = Customers.OrderBy(c => c.CustomerId).ToList();
            if (Gems != null) Gems = Gems.OrderBy(g => g.GemId).ToList();
            if (Golds != null) Golds = Golds.OrderBy(b => b.GoldId).ToList();
            if (Invoices != null) Invoices = Invoices.OrderBy(i => i.InvoiceId).ToList();
            if (InvoiceItems != null) InvoiceItems = InvoiceItems.OrderBy(t => t.InvoiceItemId).ToList();
            //if (Products != null) Products = Products.OrderBy(p => p.ProductCode).ToList();
            if (Users != null) Users = Users.OrderBy(u => u.UserId).ToList();
            if (Warranties != null) Warranties = Warranties.OrderBy(w => w.WarrantyId).ToList();
            if (GoldPrices != null) GoldPrices = GoldPrices.OrderBy(c => c.Name).ToList();


        }

        public bool VerifyAuth(string role)
        {
            bool result = false;
            bool isAuthenticated = HttpContext.Session.GetObject<bool>(SessionKeyAuthState);
            User user = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
            if (isAuthenticated && user != null)
            {
                if(user.Role == role)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
//bool isAuthenticated = HttpContext.Session.GetObject<bool>(SessionKeyAuthState);
//User user = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

//return isAuthenticated && user?.Role.Equals(role) == true;