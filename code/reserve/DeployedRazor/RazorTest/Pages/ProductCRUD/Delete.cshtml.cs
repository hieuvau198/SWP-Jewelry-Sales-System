using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.ProductCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly ProductService _productService;

        public DeleteModel(ProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
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
                return RedirectToPage("/ProductCRUD/ProductDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the product.");
            return Page();
        }
    }
}
