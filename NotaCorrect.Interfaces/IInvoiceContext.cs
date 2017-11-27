using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NotaCorrect.Interfaces
{
    public interface IInvoiceContext
    {
        DataTable GetAllInvoices();

        DataTable GetInvoiceByID(int InvoiceID);

        void ChangeInvoiceStatus(int InvoiceID, string NewStatus);
    }
}