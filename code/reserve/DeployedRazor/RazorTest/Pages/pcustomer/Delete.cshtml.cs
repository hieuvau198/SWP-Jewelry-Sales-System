using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.pcustomer
{
    public class DeleteModel : PageModel
    {
        private readonly CustomerService _customerService;

        public DeleteModel(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Customer = await _customerService.GetCustomerByIdAsync(id);
            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _customerService.DeleteCustomerAsync(Customer.CustomerId);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/pcustomer/CustomerDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the customer.");
            return Page();
        }
    }
}
