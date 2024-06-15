using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
        public const string SessionKeyCustomerId = "_CustomerId";
        public const string SessionKeySearchCustomer = "_SearchCustomer";
        public const string SessionKeyCustomerObject = "_CustomerObject";
        private readonly ApiService _apiService;
        private readonly ILogger<CartModel> _logger;
        public const string UrlUpdatePrice = "http://localhost:5071/api/product/UpdatePrice\r\n";
        public const string UrlUpdatePrices = "http://localhost:5071/api/product/UpdatePrices\r\n";
        public const string UrlGetCustomers = "http://localhost:5071/api/customer\r\n";

        public CartModel(ApiService apiService, ILogger<CartModel> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        public List<Product> Cart { get; set; }
        public Customer Customer { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public const int PageSize = 6; // Number of products per page

        public async Task OnGetAsync(int currentPage = 1)
        {
            Cart = HttpContext.Session.GetObject<List<Product>>(SessionKeyCart) ?? new List<Product>();
            
            if(HttpContext.Session.GetString(SessionKeyCustomerId)==null)
            {
                Customer = new Customer();
                Customer.CustomerName = "Not Identified";
            }
            else
            {
                Customer = HttpContext.Session.GetObject<Customer>(SessionKeyCustomerObject);
            }


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
        public async Task<IActionResult> OnPostEditProduct(string productId, int quantity)
        {
            Cart = HttpContext.Session.GetObject<List<Product>>(SessionKeyCart) ?? new List<Product>();
            var product = Cart.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                product.ProductQuantity = quantity;
                Product updatedProduct = await _apiService.PostAsJsonAndDeserializeAsync<Product>(UrlUpdatePrice, product);
                Cart.Remove(product);
                Cart.Add(updatedProduct);
                
                HttpContext.Session.SetObject(SessionKeyCart, Cart);
            }
            
            return RedirectToPage(new { currentPage = CurrentPage });
        }
        
        public async Task<IActionResult> OnPostAddCustomer(string searchCustomer)
        {
            List<Customer> customers = await _apiService.GetAsync<List<Customer>>(UrlGetCustomers);
            Customer customer = customers.Find(x  => x.CustomerName == searchCustomer);
            if(customer != null)
            {
                HttpContext.Session.SetString(SessionKeyCustomerId, customer.CustomerId);
                HttpContext.Session.SetObject(SessionKeyCustomerObject, customer);
            }
            else
            {
                HttpContext.Session.Remove(SessionKeyCustomerId);
                HttpContext.Session.Remove(SessionKeyCustomerObject);
            }
            HttpContext.Session.SetString(SessionKeySearchCustomer, searchCustomer);
            return RedirectToPage(new { currentPage = CurrentPage });
        }

    }
}
