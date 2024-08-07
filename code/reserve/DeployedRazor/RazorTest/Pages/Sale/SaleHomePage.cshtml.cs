﻿using RazorTest.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using RazorTest.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using RazorTest.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.CodeAnalysis;
using Microsoft.IdentityModel.Tokens;

namespace RazorTest.Pages.Sale
{
    public class SaleHomePageModel : PageModel
    {
        public const string SessionKeyAuthState = "_AuthState";
        public const string SessionKeySaleProductList = "_SaleProductList";
        public const string SessionKeyCart = "_Cart";
        public const string SessionKeyUserId = "_UserId";
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyMessage = "_Message";
        public const string SessionKeySaleInvoiceItemList = "_SaleInvoiceItemList";
        public const string SessionKeySaleInvoiceObject = "_SaleInvoiceObject";
        public const string SessionKeyDiscountList = "_DiscountList";
        public const string SessionKeySelectedProduct = "_ViewDetailProduct";

        public const string SessionKeyFilterOrder = "_FilterOrder";
        public const string SessionKeyFilterType = "_FilterType";
        public const string SessionKeyFilterGem = "_FilterGem";
        public const string SessionKeyFilterGold = "_FilterGold";

        public const string UrlUpdatePrice = "http://localhost:5071/api/product/UpdatePrice\r\n";
        public const string UrlGetDiscounts = "http://localhost:5071/api/discount\r\n";
        public const string UrlProduct = "http://localhost:5071/api/product";

        private readonly ApiService _apiService;
        private readonly ILogger<SaleHomePageModel> _logger;

        public SaleHomePageModel(ApiService apiService, ILogger<SaleHomePageModel> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }
        public User User { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public Invoice InvoiceObject { get; set; }

        public const int PageSize = 6; // Number of products per page
        public string SearchTerm { get; set; }
        public string FilterOrder { get; set; } = "None";
        public string FilterType { get; set; } = "All";
        public string FilterGem { get; set; } = "All";
        public string FilterGold { get; set; } = "All";

        public async Task<IActionResult> OnGetAsync(string searchTerm, string filterOrder, string filterType, string filterGem, string filterGold, int currentPage = 1)
        {
            try
            {
                // Verify auth
                List<string> roles = new List<string>
                {
                    "Admin",
                    "Cashier",
                    "Sale"
                };
                if (!_apiService.VerifyAuth(HttpContext, roles))
                {
                    return RedirectToPage("/Authentication/AccessDenied");
                }

                // Process data
                User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

                List<Product> products = await _apiService.GetAsync<List<Product>>(UrlProduct);

                // Process Search and Filter
                {
                    SearchTerm = searchTerm;

                    if (!string.IsNullOrEmpty(filterOrder))
                    {
                        FilterOrder = filterOrder;
                        HttpContext.Session.SetString(SessionKeyFilterOrder, filterOrder);
                    }
                    else
                    {
                        FilterOrder = HttpContext.Session.GetString(SessionKeyFilterOrder) ?? "None";
                    }
                    if (!string.IsNullOrEmpty(filterType))
                    {
                        FilterType = filterType;
                        HttpContext.Session.SetString(SessionKeyFilterType, filterType);
                    }
                    else
                    {
                        FilterType = HttpContext.Session.GetString(SessionKeyFilterType) ?? "All";
                    }
                    if (!string.IsNullOrEmpty(filterGem))
                    {
                        FilterGem = filterGem;
                        HttpContext.Session.SetString(SessionKeyFilterGem, filterGem);
                    }
                    else
                    {
                        FilterGem = HttpContext.Session.GetString(SessionKeyFilterGem) ?? "All";
                    }
                    if (!string.IsNullOrEmpty(filterGold))
                    {
                        FilterGold = filterGold;
                        HttpContext.Session.SetString(SessionKeyFilterGold, filterGold);
                    }
                    else
                    {
                        FilterGold = HttpContext.Session.GetString(SessionKeyFilterGold) ?? "All";
                    }

                    if (products.IsNullOrEmpty())
                    {
                        return RedirectToPage("/NotFound");
                    }
                }

                // Filter products based on string filterType, filterGem, filterGold
                if (!FilterType.Equals("All"))
                {
                    products = products.Where(p =>
                        (p.ProductType != null && p.ProductType.Contains(FilterType))).ToList();
                }
                if (!FilterGem.Equals("All"))
                {
                    products = products.Where(p =>
                        (p.GemName != null && p.GemName.Contains(FilterGem))).ToList();
                }
                if (!FilterGold.Equals("All"))
                {
                    products = products.Where(p =>
                        (p.GoldName != null && p.GoldName.Contains(FilterGold))).ToList();
                }
                // Search products based on string searchTerm
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    products = products.Where(p =>
                        (p.ProductCode != null && p.ProductCode.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
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

                // Make order for results
                if (!string.IsNullOrEmpty(FilterOrder) && !FilterOrder.Equals("None"))
                {
                    if(FilterOrder.Equals("By Name"))
                    {
                        products = products.OrderBy(p => p.ProductName).ToList();
                    }else if(FilterOrder.Equals("Lastest"))
                    {
                        products = products.OrderByDescending(p => p.CreatedAt).ToList();
                    }
                    else if (FilterOrder.Equals("Oldest"))
                    {
                        products = products.OrderBy(p => p.CreatedAt).ToList();
                    }
                    else if (FilterOrder.Equals("Low to High"))
                    {
                        products = products.OrderBy(p => p.UnitPrice).ToList();
                    }
                    else if (FilterOrder.Equals("High to low"))
                    {
                        products = products.OrderByDescending(p => p.UnitPrice).ToList();
                    }
                }
                else
                {
                    products = products.OrderBy(p => p.ProductCode).ToList();
                }

                // Calculate pagination details
                CurrentPage = currentPage;
                TotalPages = (int)System.Math.Ceiling(products.Count / (double)PageSize);

                Products = products.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

                // Store products in session to fetch them during post request
                HttpContext.Session.SetObject("Products", products);
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
            }

            return Page();
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
                    string discountId = "No Discount";
                    double totalPrice = 0;
                    double endPrice = 0;
                    int quantity = 1;
                    string warrantyId = "No Warranty";
                

                // Find Best Discount
                    List<Discount> Discounts = HttpContext.Session.GetObject<List<Discount>>(SessionKeyDiscountList);
                    if (Discounts == null)
                    {
                        Discounts = await _apiService.GetAsync<List<Discount>>(UrlGetDiscounts);
                        List<Discount> temp = new List<Discount>();
                        foreach (Discount discount in Discounts)
                        {
                            if (discount.ProductType.Equals("All")
                                || discount.ProductId.Equals(productId)
                                || (discount.ProductType.Equals(product.ProductType) 
                                    && discount.ProductId.Equals("All"))
                                )
                            {
                            DateTime currentTime = DateTime.Now;
                            if (discount.PublicDate < currentTime
                            && discount.ExpireDate > currentTime)
                            {
                                temp.Add(discount);
                            }
                            
                            }
                        }
                        Discounts = temp;
                    }
                
                    foreach (Discount discount in Discounts)
                    {
                        if(discount.DiscountRate > discountRate)
                        {
                            discountRate = discount.DiscountRate;
                            discountId = discount.DiscountId;
                        }
                    }
                    
                // Set product quantity and price
                    product.ProductQuantity = quantity;
                    product.TotalPrice = product.UnitPrice;
                    totalPrice = product.TotalPrice;
                    endPrice = product.UnitPrice * (1-discountRate);
                    
                // Add the updated product to cart
                    cart.Add(product);

                // Save the updated cart back to the session
                    HttpContext.Session.SetObject(SessionKeyCart, cart);

                // Set Invoice Item for this current product

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
                            DiscountId = discountId,
                            DiscountRate = discountRate,
                            TotalPrice = totalPrice,
                            EndTotalPrice = endPrice,
                            WarrantyId = warrantyId
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

        public async Task<IActionResult> OnPostViewDetail(string productId)
        {
            List<Product> products = HttpContext.Session.GetObject<List<Product>>("Products") ?? new List<Product>();

            if (productId != null && products != null)
            {
                Product product = products.Find(x => x.ProductId == productId);
                HttpContext.Session.SetObject(SessionKeySelectedProduct, product);
            }
            else
            {
                return RedirectToPage();
            }
            return RedirectToPage("./ViewDetail");
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
