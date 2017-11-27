using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotaCorrect.Interfaces;
using System.Data;

namespace NotaCorrect.DataHandling
{
    public class EmployeeSQLQuery : IEmployeeContext
    {
        DataTable IEmployeeContext.GetAllEmployees()
        {
            string query = "SELECT * FROM Employee";
            return SQL_CRUD_Methods.SQLReadNonParameter(query);
        }

        DataTable IEmployeeContext.GetEmployeeByID(int EmployeeID)
        {
            string query = "SELECT * FROM Employee WHERE ID = @EmpID";
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("@EmpID", EmployeeID)
            };
            return SQL_CRUD_Methods.SQLReadParameterized(query, parameters);
        }
    }
}
