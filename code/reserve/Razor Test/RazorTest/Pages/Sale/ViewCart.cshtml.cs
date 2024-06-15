using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.Sale
{
    public class CartModel : PageModel
    {
        public const string SessionKeyCart = "_Cart";
        private readonly ApiService _apiService;
        private readonly ILogger<CartModel> _logger;

        public CartModel(ApiService apiService, ILogger<CartModel> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        public List<Product> Cart { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public const int PageSize = 6; // Number of products per page

        public async Task OnGetAsync(int currentPage = 1)
        {
            Cart = HttpContext.Session.GetObject<List<Product>>(SessionKeyCart) ?? new List<Product>();
            Cart = await _apiService.UpdatePrice(Cart);
            // Calculate pagination details
            CurrentPage = currentPage;
            TotalPages = (int)System.Math.Ceiling(Cart.Count / (double)PageSize);

            Cart = Cart.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
        }

        public IActionResult OnPostDelete(string productId)
        {
            Cart = HttpContext.Session.GetObject<List<Product>>(SessionKeyCart) ?? new List<Product>();
            var product = Cart.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                Cart.Remove(product);
                HttpContext.Session.SetObject(SessionKeyCart, Cart);
            }

            return RedirectToPage(new { currentPage = CurrentPage });
        }
        public IActionResult OnPostEditProduct(string productId, int quantity)
        {
            Cart = HttpContext.Session.GetObject<List<Product>>(SessionKeyCart) ?? new List<Product>();
            var product = Cart.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                Cart.FirstOrDefault(p => p.ProductId == productId).ProductQuantity = quantity;
                HttpContext.Session.SetObject(SessionKeyCart, Cart);
            }
            return RedirectToPage(new { currentPage = CurrentPage });
        }

    }
}
