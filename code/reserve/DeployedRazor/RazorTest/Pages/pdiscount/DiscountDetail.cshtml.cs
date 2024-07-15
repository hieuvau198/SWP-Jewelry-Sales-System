using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.pdiscount
{
    public class DiscountListModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyAuthState = "_AuthState";

        private readonly ApiService _apiService;

        public DiscountListModel(ApiService apiService)
        {
            _apiService = apiService;
        }
        public User User { get; set; }

        // public List<Discount> Discounts { get; set; }
        public PaginatedList<Discount> Discounts { get; set; }

        private const int PageSize = 10;

        public string SearchTerm { get; set; }
        public string FilterOrderType { get; set; } = "All";
        public string FilterProductType { get; set; } = "All";

        public async Task<IActionResult> OnGetAsync(string searchTerm, string filterOrderType, string filterProductType, int currentPage = 1)
        {
            // Verify auth
            List<string> roles = new List<string>
                {
                    "Manager",
                    "Sale",
                    "Cashier",
                    "Admin"
                };
            if (!_apiService.VerifyAuth(HttpContext, roles))
            {
                return RedirectToPage("/Authentication/AccessDenied");
            }

            // Get data
            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
            var discounts = await _apiService.GetAsync<List<Discount>>("http://localhost:5071/api/discount");

            // Set search and filter parameters
            SearchTerm = searchTerm;
            FilterOrderType = !string.IsNullOrEmpty(filterOrderType) ? filterOrderType : "All";
            FilterProductType = !string.IsNullOrEmpty(filterProductType) ? filterProductType : "All";

            // Filter discounts based on order type and product type
            if (!string.IsNullOrEmpty(filterOrderType) && !filterOrderType.Equals("All"))
            {
                discounts = discounts.Where(d => d.OrderType != null && d.OrderType.Contains(filterOrderType)).ToList();
            }
            if (!string.IsNullOrEmpty(filterProductType) && !filterProductType.Equals("All"))
            {
                discounts = discounts.Where(d => d.ProductType != null && d.ProductType.Contains(filterProductType)).ToList();
            }

            // Search discounts based on searchTerm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                discounts = discounts.Where(d =>
                    (d.DiscountId.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                    (d.DiscountName != null && d.DiscountName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                    (d.OrderType != null && d.OrderType.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                    (d.ProductType != null && d.ProductType.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                    (d.PublicDate.ToString().Contains(searchTerm)) ||
                    (d.ExpireDate.ToString().Contains(searchTerm))
                ).ToList();
            }

            // Separate pages
            if (discounts != null)
            {
                Discounts = PaginatedList<Discount>.Create(discounts.AsQueryable(), currentPage, PageSize);
            }

            return Page();
        }


        public bool VerifyAuth(string role)
        {
            bool result = false;
            bool isAuthenticated = HttpContext.Session.GetObject<bool>(SessionKeyAuthState);
            User user = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
            if (isAuthenticated && user != null)
            {
                if (user.Role == role)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
