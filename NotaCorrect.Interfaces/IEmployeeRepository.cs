using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotaCorrect.Models;

namespace NotaCorrect.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeByID(int EmployeeID);
    }
}