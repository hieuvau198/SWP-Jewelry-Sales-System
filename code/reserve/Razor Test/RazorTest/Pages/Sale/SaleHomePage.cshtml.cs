using RazorTest.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using RazorTest.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using RazorTest.Utilities;

namespace RazorTest.Pages.Sale
{
    public class SaleHomePageModel : PageModel
    {
        public const string SessionKeyCart = "_Cart";
        private readonly ApiService _apiService;
        private readonly ILogger<SaleHomePageModel> _logger;

        public SaleHomePageModel(ApiService apiService, ILogger<SaleHomePageModel> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        public List<Product> Products { get; set; } = new List<Product>();

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public const int PageSize = 6; // Number of products per page

        public async Task OnGetAsync(int currentPage = 1)
        {
            var allProducts = await _apiService.GetAsync<List<Product>>("http://localhost:5071/api/product");

            // Calculate pagination details
            CurrentPage = currentPage;
            TotalPages = (int)System.Math.Ceiling(allProducts.Count / (double)PageSize);

            Products = allProducts.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

            // Store products in session to fetch them during post request
            HttpContext.Session.SetObject("Products", allProducts);
        }

        public IActionResult OnPostAddToCart(string productId)
        {
            // Fetch products again to find the product by Id
            var allProducts = HttpContext.Session.GetObject<List<Product>>("Products") ?? new List<Product>();

            List<Product> cart = HttpContext.Session.GetObject<List<Product>>(SessionKeyCart) ?? new List<Product>();

            Product product = allProducts.Find(x => x.ProductId == productId);
            if (product != null && !cart.Exists(x => x.ProductId == productId))
            {
                cart.Add(product);
                HttpContext.Session.SetObject(SessionKeyCart, cart);
            }

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return new JsonResult(new { success = true });
            }

            return RedirectToPage(new { currentPage = CurrentPage });
        }
    }
}
