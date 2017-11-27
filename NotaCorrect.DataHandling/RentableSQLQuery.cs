using NotaCorrect.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaCorrect.DataHandling
{
    public class RentableSQLQuery : IRentableContext
    {
        DataTable IRentableContext.GetAllRentables()
        {
            string query = "SELECT * FROM Rentable";
            return SQL_CRUD_Methods.SQLReadNonParameter(query);
        }

        DataTable IRentableContext.GetRentablesForInvoice(int InvoiceID)
        {
            string query = "SELECT * FROM Invoice_Rentable WHERE InvoiceID = @InvID";
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("@InvID", InvoiceID)
            };
            return SQL_CRUD_Methods.SQLReadParameterized(query, parameters);
        }

        DataTable IRentableContext.GetRentableByID(int RentableID)
        {
            string query = "SELECT * FROM Rentable WHERE ID = @RentID";
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("@RentID", RentableID)
            };
            return SQL_CRUD_Methods.SQLReadParameterized(query, parameters);
        }
    }
}
