using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotaCorrect.Models;

namespace NotaCorrect.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerByID(int CustomerID);
        bool SaveNewCustomer(Customer Customer);
    }
}
    