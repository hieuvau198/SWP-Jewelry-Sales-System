using JewelBO;

namespace JewelService.ServiceInvoice
{
    public interface IInvoiceService
    {
        List<Invoice> GetInvoices();
        Invoice GetInvoice(string invoiceId);
        Invoice AddInvoice(Invoice invoice);
        bool RemoveInvoice(string invoiceId);
        bool UpdateInvoice(Invoice invoice);
    }
}
