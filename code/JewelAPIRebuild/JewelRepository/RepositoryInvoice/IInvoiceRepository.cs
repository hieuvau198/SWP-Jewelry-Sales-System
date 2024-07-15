

using JewelBO;

namespace JewelRepository.RepositoryInvoice
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetInvoices();
        Invoice GetInvoice(string invoiceId);
        Invoice AddInvoice(Invoice invoice);
        bool RemoveInvoice(string invoiceId);
        bool UpdateInvoice(Invoice invoice);
    }
}
