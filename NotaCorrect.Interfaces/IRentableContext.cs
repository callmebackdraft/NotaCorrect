using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NotaCorrect.Interfaces
{
    public interface IRentableContext
    {
        DataTable GetAllRentables();
        DataTable GetRentablesForInvoice(int InvoiceID);
        DataTable GetRentableByID(int RentableID);
    }
}