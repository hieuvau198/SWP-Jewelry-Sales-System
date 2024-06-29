using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.ProductCRUD
{

    public class ProductListModel : PageModel
    {

        public const string SessionKeyAuthState = "_AuthState";
        public const string SessionKeyUserObject = "_UserObject";

        private readonly ApiService _apiService;

        public ProductListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

       // public List<Product> Products { get; set; }
        public User User { get; set; }

        public PaginatedList<Product> Products { get; set; }

        public string SearchTerm { get; set; }

        private const int PageSize = 10;
        public async Task OnGetAsync(string searchTerm ,int currentPage = 1)
        {
            SearchTerm = searchTerm;

            var products = await _apiService.GetAsync<List<Product>>("http://localhost:5071/api/product");
            
            // Filter products based on the search term
            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p =>
                    (p.ProductCode != null && p.ProductCode.Contains(searchTerm)) ||
                    (p.ProductName != null && p.ProductName.Contains(searchTerm)) ||
                    (p.ProductQuantity.ToString().Contains(searchTerm)) ||
                    (p.ProductType != null && p.ProductType.Contains(searchTerm)) ||
                    (p.ProductWarranty.ToString().Contains(searchTerm)) ||
                    (p.GemName != null && p.GemName.Contains(searchTerm)) ||
                    (p.GemWeight.ToString().Contains(searchTerm)) ||
                    (p.GoldName != null && p.GoldName.Contains(searchTerm)) ||
                    (p.GoldWeight.ToString().Contains(searchTerm)) ||
                    (p.BuyPrice.ToString().Contains(searchTerm)) ||
                    (p.UnitPrice.ToString().Contains(searchTerm))).ToList();
            }

            if (products != null)
            {
                Products = PaginatedList<Product>.Create(products.AsQueryable(), currentPage, 10);
            }
        }
        public bool VerifyAuth(string role)
        {
            bool result = false;
            if (HttpContext.Session.GetObject<bool>(SessionKeyAuthState)
                && HttpContext.Session.GetObject<User>(SessionKeyUserObject).Role.Equals(role))
            {
                result = true;
            }
            return result;
        }
    }
}
