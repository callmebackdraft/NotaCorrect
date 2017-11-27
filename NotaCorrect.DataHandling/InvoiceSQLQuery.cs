using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotaCorrect.Interfaces;
using System.Data;

namespace NotaCorrect.DataHandling
{
    public class InvoiceSQLQuery : IInvoiceContext
    {
        void IInvoiceContext.ChangeInvoiceStatus(int InvoiceID, string NewStatus)
        {
            string query = "UPDATE Invoice SET Status = @Status , LastChangeDate = @DateTime   WHERE ID = @InvoiceID";
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("@Status", NewStatus),
                new KeyValuePair<string, object>("@InvoiceID", InvoiceID),
                new KeyValuePair<string, object>("@DateTime", DateTime.Now)
            };
            SQL_CRUD_Methods.SQLUpdate(query, parameters);
        }

        DataTable IInvoiceContext.GetAllInvoices()
        {
            string query = "SELECT * FROM Invoice";
            return SQL_CRUD_Methods.SQLReadNonParameter(query);
        }

        DataTable IInvoiceContext.GetInvoiceByID(int InvoiceID)
        {
            string query = "SELECT* FROM Invoice WHERE ID = @InvID";
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("@InvID", InvoiceID)
            };
            return SQL_CRUD_Methods.SQLReadParameterized(query, parameters);
        }
    }
}
