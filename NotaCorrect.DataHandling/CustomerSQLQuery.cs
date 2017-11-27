using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotaCorrect.Interfaces;
using System.Data;

namespace NotaCorrect.DataHandling
{
    public class CustomerSQLQuery : ICustomerContext
    {
        DataTable ICustomerContext.GetAllCustomers()
        {
            string query = "Select * FROM [Customer]";
            return SQL_CRUD_Methods.SQLReadNonParameter(query);
        }

        DataTable ICustomerContext.GetCustomerByID(int CustomerID)
        {
            string query = "SELECT * FROM [Customer] WHERE ID = @CustID";
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("@CustID", CustomerID)
            };
            return SQL_CRUD_Methods.SQLReadParameterized(query, parameters);
        }

        bool ICustomerContext.SaveNewCustomer()
        {
            throw new NotImplementedException();
        }
    }
}
