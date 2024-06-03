using JewelSystemBE.Model;
using JewelSystemBE.Service.ServiceInvoice;
using Microsoft.AspNetCore.Mvc;

namespace JewelSystemBE.Controllers
{
    [Route("api/invoice")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_invoiceService.GetInvoices());
        }

        [HttpGet("{invoiceId}")]
        public IActionResult Get(string invoiceId)
        {
            if (invoiceId == null)
            {
                return BadRequest(new { message = "You missed invoiceId." });
            }

            var invoice = _invoiceService.GetInvoice(invoiceId);
            if (invoice == null)
            {
                return NotFound(new { message = "Invoice not found." });
            }

            return Ok(invoice);
        }

        [HttpPost]
        public IActionResult Post(Invoice invoice)
        {
            return Ok(_invoiceService.AddInvoice(invoice));
        }

        [HttpPut]
        public IActionResult Put(Invoice invoice)
        {
            return Ok(_invoiceService.UpdateInvoice(invoice));
        }

        [HttpDelete]
        public IActionResult Delete(string invoiceId)
        {
            return Ok(_invoiceService.RemoveInvoice(invoiceId));
        }
    }
}
