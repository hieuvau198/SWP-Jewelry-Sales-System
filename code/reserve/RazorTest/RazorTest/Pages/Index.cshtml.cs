using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Pages.Authentication;
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
            

            const int pageSize = 9; // Number of products per page
            Products = await _apiService.GetAsync<List<Product>>("http://localhost:5071/api/product");

            if (Products != null)
            {
                Products = Products.OrderBy(p => p.ProductCode).ToList();
                PaginatedProducts = PaginatedList<Product>.Create(Products.AsQueryable(), pageIndex ?? 1, pageSize);
            }
            else
            {
                Products = new List<Product>();
                Products = Products.OrderBy(p => p.ProductCode).ToList();
                PaginatedProducts = PaginatedList<Product>.Create(Products.AsQueryable(), pageIndex ?? 1, pageSize);
            }
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
