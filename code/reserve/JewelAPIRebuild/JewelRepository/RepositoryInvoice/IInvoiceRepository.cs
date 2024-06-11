

using JewelBO;

namespace JewelRepository.RepositoryInvoice
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetInvoices();
        Invoice GetInvoice(string invoiceId);
        bool AddInvoice(Invoice invoice);
        bool RemoveInvoice(string invoiceId);
        bool UpdateInvoice(Invoice invoice);
    }
}
