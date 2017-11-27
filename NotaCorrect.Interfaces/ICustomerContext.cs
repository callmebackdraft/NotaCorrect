using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NotaCorrect.Interfaces
{
    public interface ICustomerContext
    {
        DataTable GetAllCustomers();
        DataTable GetCustomerByID(int CustomerID);
        bool SaveNewCustomer();
    }
}