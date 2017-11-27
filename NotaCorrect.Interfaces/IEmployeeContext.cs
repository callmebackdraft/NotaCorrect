using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NotaCorrect.Interfaces
{
    public interface IEmployeeContext
    {
        DataTable GetAllEmployees();
        DataTable GetEmployeeByID(int EmployeeID);
    }
}