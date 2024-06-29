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
        public string FilterType { get; set; } = "All";
        public string FilterGem { get; set; } = "All";
        public string FilterGold { get; set; } = "All";
        

        private const int PageSize = 10;
        public async Task OnGetAsync(string searchTerm, string filterType, string filterGem, string filterGold, int currentPage = 1)
        {
            // Set some vars
                SearchTerm = searchTerm;
                if(!string.IsNullOrEmpty(filterType))
                {
                    FilterType = filterType;
                }
                if (!string.IsNullOrEmpty(filterGem))
                {
                    FilterGem = filterGem;
                }
                if (!string.IsNullOrEmpty(filterGold))
                {
                    FilterGold = filterGold;
                }


            var products = await _apiService.GetAsync<List<Product>>("http://localhost:5071/api/product");
            
            // Filter products based on string filterType, filterGem, filterGold
                if(!string.IsNullOrEmpty(filterType) && !filterType.Equals("All"))
                {
                    products = products.Where(p => 
                        (p.ProductType != null && p.ProductType.Contains(filterType))).ToList();
                }
                if (!string.IsNullOrEmpty(filterGem) && !filterGem.Equals("All"))
                {
                    products = products.Where(p =>
                        (p.GemName != null && p.GemName.Contains(filterGem))).ToList();
                }
                if (!string.IsNullOrEmpty(filterGold) && !filterGold.Equals("All"))
                {
                    products = products.Where(p =>
                        (p.GoldName != null && p.GoldName.Contains(filterGold))).ToList();
                }
            // Search products based on string searchTerm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p =>
                    (p.ProductCode != null && p.ProductCode.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                    (p.ProductName != null && p.ProductName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
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
