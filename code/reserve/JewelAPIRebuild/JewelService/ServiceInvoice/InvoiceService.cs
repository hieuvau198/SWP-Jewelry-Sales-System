using JewelBO;
using JewelDAL;
using JewelRepository.RepositoryInvoice;

namespace JewelService.ServiceInvoice
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            this._invoiceRepository = invoiceRepository;
        }

        public bool AddInvoice(Invoice invoice)
        {
            return _invoiceRepository.AddInvoice(invoice);
        }

        public List<Invoice> GetInvoices()
        {
            return _invoiceRepository.GetInvoices();
        }

        public Invoice GetInvoice(string invoiceId)
        {
            return _invoiceRepository.GetInvoice(invoiceId);
        }

        public bool RemoveInvoice(string invoiceId)
        {
            return _invoiceRepository.RemoveInvoice(invoiceId);
        }

        public bool UpdateInvoice(Invoice invoice)
        {
            return (_invoiceRepository.UpdateInvoice(invoice));
        }
    }
}
