using JewelBO;
using JewelService.ServiceInvoiceItem;
using Microsoft.AspNetCore.Mvc;

namespace JewelAPI.Controllers
{
    [Route("api/invoiceitem")]
    [ApiController]
    public class InvoiceItemController : ControllerBase
    {
        private readonly IInvoiceItemService _invoiceItemService;

        public InvoiceItemController(IInvoiceItemService invoiceItemService)
        {
            _invoiceItemService = invoiceItemService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_invoiceItemService.GetInvoiceItems());
        }

        [HttpGet("{invoiceItemId}")]
        public IActionResult Get(string invoiceItemId)
        {
            if (string.IsNullOrWhiteSpace(invoiceItemId))
            {
                return BadRequest(new { message = "Invalid invoice item ID." });
            }

            var invoiceItem = _invoiceItemService.GetInvoiceItem(invoiceItemId);
            if (invoiceItem == null)
            {
                return NotFound(new { message = "Invoice item not found." });
            }

            return Ok(invoiceItem);
        }

        [HttpPost]
        public IActionResult Post(InvoiceItem invoiceItem)
        {
            return Ok(_invoiceItemService.AddInvoiceItem(invoiceItem));
        }

        [HttpPut]
        public IActionResult Put(InvoiceItem invoiceItem)
        {
            return Ok(_invoiceItemService.UpdateInvoiceItem(invoiceItem));
        }

        [HttpDelete]
        public IActionResult Delete(string invoiceItemId)
        {
            return Ok(_invoiceItemService.RemoveInvoiceItem(invoiceItemId));
        }
    }
}
