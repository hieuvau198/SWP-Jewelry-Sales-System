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
        public const string SessionKeySaleDiscountProductId = "_SaleDiscountProductId";
        public const string SessionKeyCustomerId = "_CustomerId";
        public const string SessionKeySearchCustomer = "_SearchCustomer";
        public const string SessionKeyCustomerObject = "_CustomerObject";
        public const string SessionKeySaleInvoiceItemList = "_SaleInvoiceItemList";
        public const string SessionKeySaleInvoiceObject = "_SaleInvoiceObject";
        public const string SessionKeySaleDiscountSelectedList = "_SaleDiscountSelectedList";

        public const string SessionKeyAuthState = "_AuthState";
        public const string SessionKeyUserObject = "_UserObject";

        public const string UrlUpdatePrice = "http://localhost:5071/api/product/UpdatePrice\r\n";
        public const string UrlUpdatePrices = "http://localhost:5071/api/product/UpdatePrices\r\n";
        public const string UrlGetCustomers = "http://localhost:5071/api/customer\r\n";

        private readonly ApiService _apiService;
        private readonly ILogger<CartModel> _logger;
        

        public CartModel(ApiService apiService, ILogger<CartModel> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        public List<Product> Cart { get; set; }
        public Customer Customer { get; set; }
        public User User { get; set; }
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

            if(User == null)
            {
                User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
            }
            // Calculate pagination details
            CurrentPage = currentPage;
            TotalPages = (int)System.Math.Ceiling(Cart.Count / (double)PageSize);

            Cart = Cart.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
        }

        public IActionResult OnPostDelete(string productId)
        {
            Cart = HttpContext.Session.GetObject<List<Product>>(SessionKeyCart) ?? new List<Product>();
            List<InvoiceItem> invoiceItems = HttpContext.Session.GetObject<List<InvoiceItem>>(SessionKeySaleInvoiceItemList);
            var product = Cart.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                Cart.Remove(product);
                HttpContext.Session.SetObject(SessionKeyCart, Cart);
            }
            var invoiceItem = invoiceItems.Find(x => x.ProductId == productId);
            if (invoiceItem != null)
            {
                invoiceItems.Remove(invoiceItem);
                HttpContext.Session.SetObject(SessionKeySaleInvoiceItemList, invoiceItems);
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
                Product updatedProduct = product;
                updatedProduct.TotalPrice = product.UnitPrice * quantity;
                Cart.Remove(product);
                Cart.Add(updatedProduct);
                
                HttpContext.Session.SetObject(SessionKeyCart, Cart);
            }


            
            return RedirectToPage(new { currentPage = CurrentPage });
        }

        public async Task<IActionResult> OnPostAddCustomer(string searchCustomer)
        {
            // Retrieve list of customers from API
            List<Customer> customers = await _apiService.GetAsync<List<Customer>>(UrlGetCustomers);

            // Find customer by name in the list
            Customer = customers.Find(x => x.CustomerName == searchCustomer);

            if (Customer != null)
            {
                // Customer found: Store customer info in session
                HttpContext.Session.SetString(SessionKeyCustomerId, Customer.CustomerId);
                HttpContext.Session.SetObject(SessionKeyCustomerObject, Customer);
            }
            else
            {
                // Customer not found: Display message and clear session data
                HttpContext.Session.Remove(SessionKeyCustomerId);
                HttpContext.Session.Remove(SessionKeyCustomerObject);

                // Set message to inform user
                TempData["Message"] = "Customer not found. Please add new customer.";
            }

            // Store search customer in session for display purposes
            HttpContext.Session.SetString(SessionKeySearchCustomer, searchCustomer);

            // Redirect to current page
            return RedirectToPage(new { currentPage = CurrentPage });
        }


        public async Task<IActionResult> OnPostSelectDiscount(string productId)
        {
            
            HttpContext.Session.SetString(SessionKeySaleDiscountProductId, productId);
            return RedirectToPage("/Sale/SelectDiscountPage");
        }
        public async Task<IActionResult> OnPostCheckout()
        {
            Customer customer = HttpContext.Session.GetObject<Customer>(SessionKeyCustomerObject);
            User user = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
            Invoice savedInvoice = HttpContext.Session.GetObject<Invoice>(SessionKeySaleInvoiceObject);
            List<Product> cart = HttpContext.Session.GetObject<List<Product>>(SessionKeyCart);
            List<InvoiceItem> invoiceItems = HttpContext.Session.GetObject<List<InvoiceItem>>(SessionKeySaleInvoiceItemList);
            List<Discount> discounts = HttpContext.Session.GetObject<List<Discount>>(SessionKeySaleDiscountSelectedList) ?? new List<Discount>();

            string customerId = "Some Customer ID";
            string customerName = "Some Customer Name";
            string userId = "Some User ID";
            string userFullname = "Some User Full Name";
            string invoiceId;
            string invoiceOrderType = "Sale";
            string invoiceStatus = "Pending";
            double invoiceEndTotalPrice = 0;
            double invoiceTotalPrice = 0;
            DateTime invoiceDate = DateTime.Now;

            if (customer != null)
            {
                customerId = customer.CustomerId;
                customerName = customer.CustomerName;
            }

            if(user != null)
            {
                userId = user.UserId;
                userFullname = user.Fullname;
            }

            if(savedInvoice==null)
            {
                invoiceId = Guid.NewGuid().ToString();
            }
            else
            {
                invoiceId = savedInvoice.InvoiceId;
            }

            if (invoiceItems != null)
            {
                List<InvoiceItem> tempInvoiceItems = new List<InvoiceItem>();
                foreach (var item in invoiceItems)
                {
                    Product product = cart.Find(x => x.ProductId == item.ProductId);
                    if (product != null)
                    {
                        item.UnitPrice = product.UnitPrice;
                        item.Quantity = product.ProductQuantity;
                        item.TotalPrice = product.TotalPrice;
                        
                    }
                    Discount discount = discounts.Find(x => x.ProductId == item.ProductId);
                    if(discount != null && discount.DiscountRate > 0)
                    {
                        item.DiscountId = discount.DiscountId;
                        item.DiscountRate = discount.DiscountRate;
                        item.EndTotalPrice = (1 - discount.DiscountRate) * item.TotalPrice;
                        invoiceTotalPrice += item.TotalPrice;
                        invoiceEndTotalPrice += item.EndTotalPrice;
                    }
                    else
                    {
                        item.EndTotalPrice = item.TotalPrice;
                        invoiceTotalPrice += item.TotalPrice;
                        invoiceEndTotalPrice += item.EndTotalPrice;
                    }
                    tempInvoiceItems.Add(item);
                }
                HttpContext.Session.SetObject(SessionKeySaleInvoiceItemList, tempInvoiceItems);
            }

            
            
            Invoice invoice = new Invoice
            {
                    InvoiceId = invoiceId,
                    CustomerId = customerId,
                    CustomerName = customerName,
                    CustomerVoucher = 0,
                    EndTotalPrice = invoiceEndTotalPrice,
                    InvoiceDate = invoiceDate,
                    InvoiceStatus = invoiceStatus,
                    InvoiceType = invoiceOrderType,
                    TotalPrice = invoiceTotalPrice,
                    UserId = userId,
                    UserFullname = userFullname
                };
            HttpContext.Session.SetObject(SessionKeySaleInvoiceObject, invoice);
            return RedirectToPage("/Sale/CheckOutPage");
        }

    }
}
