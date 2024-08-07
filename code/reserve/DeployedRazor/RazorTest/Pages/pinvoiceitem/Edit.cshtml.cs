﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Threading.Tasks;

namespace RazorTest.Pages.pinvoiceitem
{
    public class EditModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyAuthState = "_AuthState";
        private readonly InvoiceItemService _invoiceItemService;
        private readonly ApiService _apiService;
        private readonly ILogger<EditModel> _logger;
        public EditModel(ApiService apiService, ILogger<EditModel> logger, InvoiceItemService invoiceItemService)
        {
            _invoiceItemService = invoiceItemService;
            _apiService = apiService;
            _logger = logger;
        }
        public User User { get; set; }
        [BindProperty]
        public InvoiceItem InvoiceItem { get; set; }

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
            if (id == null)
            {
                _logger.LogError("ID is null");
                return NotFound();
            }

            InvoiceItem = await _invoiceItemService.GetInvoiceItemByIdAsync(id);

            if (InvoiceItem == null)
            {
                _logger.LogError($"Invoice Item not found for ID {id}");
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        _logger.LogError($"Key: {modelStateKey}, Error: {error.ErrorMessage}");
                    }
                }

                return Page();
            }

            _logger.LogInformation($"Updating invoice item with ID {InvoiceItem.InvoiceItemId}");
            _logger.LogInformation($"Invoice details: {JsonConvert.SerializeObject(InvoiceItem)}");

            var response = await _invoiceItemService.UpdateInvoiceItemAsync(InvoiceItem);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Failed to update invoice item. Status Code: {response.StatusCode}");
                ModelState.AddModelError(string.Empty, "An error occurred while updating the invoice item.");
                return Page();
            }

            _logger.LogInformation("Successfully updated invoice item");
            return RedirectToPage("./InvoiceItemDetail");
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