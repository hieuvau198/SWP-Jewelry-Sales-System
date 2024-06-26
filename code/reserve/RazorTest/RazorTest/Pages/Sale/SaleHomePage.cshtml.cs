using RazorTest.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using RazorTest.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using RazorTest.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.CodeAnalysis;

namespace RazorTest.Pages.Sale
{
    public class SaleHomePageModel : PageModel
    {
        public const string SessionKeySaleProductList = "_SaleProductList";
        public const string SessionKeyCart = "_Cart";
        public const string SessionKeyUserId = "_UserId";
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyMessage = "_Message";
        public const string SessionKeySaleInvoiceItemList = "_SaleInvoiceItemList";
        public const string SessionKeySaleInvoiceObject = "_SaleInvoiceObject";
        public const string SessionKeyDiscountList = "_DiscountList";

        public const string UrlUpdatePrice = "http://localhost:5071/api/product/UpdatePrice\r\n";
        public const string UrlGetDiscounts = "http://localhost:5071/api/discount\r\n";

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
        public Invoice InvoiceObject { get; set; }

        public const int PageSize = 9; // Number of products per page

        public async Task OnGetAsync(int currentPage = 1)
        {
            if(HttpContext.Session.GetObject<User>(SessionKeyUserObject)==null )
            {
                HttpContext.Session.SetString(SessionKeyMessage, "Not Authen");
                RedirectToPage("/Index");
            }else
            {
                HttpContext.Session.SetString(SessionKeyMessage, "Is authen");
            }

            List<Product> allProducts = HttpContext.Session.GetObject<List<Product>>(SessionKeySaleProductList);
            if(allProducts == null  || allProducts.Count == 0 )
            {
                allProducts = await _apiService.GetAsync<List<Product>>("http://localhost:5071/api/product");
            }

            // S?p x?p danh sách s?n ph?m theo Product Code
            allProducts = allProducts.OrderBy(p => p.ProductCode).ToList();

            

            // Calculate pagination details
            CurrentPage = currentPage;
            TotalPages = (int)System.Math.Ceiling(allProducts.Count / (double)PageSize);

            Products = allProducts.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            

            // Store products in session to fetch them during post request
            HttpContext.Session.SetObject("Products", allProducts);
            HttpContext.Session.SetString(SessionKeyUserId, "Fuck");
        }

        public async Task<IActionResult> OnPostAddToCart(string productId)
        {
            // Fetch products again to find the product by Id
            var allProducts = HttpContext.Session.GetObject<List<Product>>("Products") ?? new List<Product>();

            List<Product> cart = HttpContext.Session.GetObject<List<Product>>(SessionKeyCart) ?? new List<Product>();

            Product product = allProducts.Find(x => x.ProductId == productId);
            if (product != null && !cart.Exists(x => x.ProductId == productId))
            {
                //Set some vars
                    double discountRate = 0;
                    double totalPrice = 0;
                    double endPrice = 0;
                    int quantity = 1;
                

                // Find Best Discount
                    List<Discount> Discounts = HttpContext.Session.GetObject<List<Discount>>(SessionKeyDiscountList);
                    if (Discounts == null)
                    {
                        Discounts = await _apiService.GetAsync<List<Discount>>(UrlGetDiscounts);
                        List<Discount> temp = new List<Discount>();
                        foreach (Discount discount in Discounts)
                        {
                            if (discount.ProductId.Equals("All")
                                || discount.ProductId.Equals(productId))
                            {
                                temp.Add(discount);
                            }
                        }
                        Discounts = temp;
                    }
                
                    foreach (Discount discount in Discounts)
                    {
                        if(discount.DiscountRate > discountRate)
                        {
                            discountRate = discount.DiscountRate;
                        }
                    }
                // Set the quantity of the product to 1
                    product.ProductQuantity = quantity;
                    product.TotalPrice = product.UnitPrice;
                    totalPrice = product.TotalPrice;
                    endPrice = product.UnitPrice * (1-discountRate);
                    
                // Update the price by calling an external API
                //Product updatedProduct = await _apiService.PostAsJsonAndDeserializeAsync<Product>(UrlUpdatePrice, product);

                // Add the updated product to the cart
                cart.Add(product);

                // Save the updated cart back to the session
                HttpContext.Session.SetObject(SessionKeyCart, cart);

                List<InvoiceItem> invoiceItems = HttpContext.Session.GetObject<List<InvoiceItem>>(SessionKeySaleInvoiceItemList);
                if (invoiceItems == null)
                {
                    invoiceItems = new List<InvoiceItem>();
                }
                if (invoiceItems.Find(x => x.ProductId == productId) == null)
                {
                    InvoiceItem invoiceItem = new InvoiceItem
                    {
                        InvoiceItemId = Guid.NewGuid().ToString(),
                        InvoiceId = "Test",
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        Quantity = product.ProductQuantity,
                        UnitPrice = product.UnitPrice,
                        DiscountId = "T",
                        DiscountRate = discountRate,
                        TotalPrice = totalPrice,
                        EndTotalPrice = endPrice,
                        WarrantyId = "Test"
                    };
                    invoiceItems.Add(invoiceItem);
                }
                HttpContext.Session.SetObject(SessionKeySaleInvoiceItemList, invoiceItems);

            }
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return new JsonResult(new { success = true });
            }
            return RedirectToPage(new { currentPage = CurrentPage });
        }
    }
}
