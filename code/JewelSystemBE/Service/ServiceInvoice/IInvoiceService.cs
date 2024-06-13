﻿using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceInvoice
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
