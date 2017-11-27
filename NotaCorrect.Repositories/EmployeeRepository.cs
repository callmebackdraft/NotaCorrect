using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotaCorrect.Interfaces;
using NotaCorrect.Models;
using NotaCorrect.DataHandling;
using System.Data;

namespace NotaCorrect.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        IEmployeeContext Empctx;

        public EmployeeRepository()
        {
            Empctx = new EmployeeSQLQuery();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> result = new List<Employee>();
            DataTable rawData = Empctx.GetAllEmployees();
            foreach(DataRow dr in rawData.Rows)
            {
                result.Add(DataRowToEmployee(dr));
            }
            return result;
        }

        public Employee GetEmployeeByID(int EmployeeID)
        {
            DataTable rawData = Empctx.GetEmployeeByID(EmployeeID);
            return DataRowToEmployee(rawData.Rows[0]);
        }

        private Employee DataRowToEmployee(DataRow dr)
        {
            return new Employee( 
                Convert.ToInt16(dr.Field<decimal>("ID")),
                dr.Field<string>("Name")
                );
        }

    }
}