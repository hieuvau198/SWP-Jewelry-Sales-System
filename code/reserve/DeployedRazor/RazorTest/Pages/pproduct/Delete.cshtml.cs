using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Threading.Tasks;

namespace RazorTest.Pages.pproduct
{
    public class DeleteModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        private readonly ProductService _productService;
        private readonly ApiService _apiService;

        public DeleteModel(ProductService productService, ApiService apiService)
        {
            _productService = productService;
            _apiService = apiService;
        }
        public User User { get; set; }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            // Verify auth
            List<string> roles = new List<string>
            {
                "Admin"
            };
            if (!_apiService.VerifyAuth(HttpContext, roles))
            {
                return RedirectToPage("/Authentication/AccessDenied");
            }

            // Process data
            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
            Product = await _productService.GetProductByIdAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _productService.DeleteProductAsync(Product.ProductId);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/pproduct/ProductDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the product.");
            return Page();
        }
    }
}
