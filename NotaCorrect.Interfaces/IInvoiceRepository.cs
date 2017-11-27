using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotaCorrect.Models;

namespace NotaCorrect.Interfaces
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetAllInvoices();

        Invoice GetInvoiceByID(int invoiceID);

        void ChangeInvoiceStatus(int invoiceID, string status);
    }
}