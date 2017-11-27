using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotaCorrect.Models;

namespace NotaCorrect.Interfaces
{
    public interface IRentableRepository
    {
        List<Rentable> GetAllRentables();
        List<Rentable> GetRentablesForInvoice(int InvoiceID);
        Rentable GetRentableByID(int RentableID);
    }
}
