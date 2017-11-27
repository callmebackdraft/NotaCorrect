using NotaCorrect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotaCorrect.Models;
using NotaCorrect.DataHandling;
using System.Data;

namespace NotaCorrect.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        ICustomerContext Custctx;

        public CustomerRepository()
        {
            Custctx = new SQLConnect();
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> result = new List<Customer>();
            DataTable rawData = Custctx.GetAllCustomers();
            foreach(DataRow dr in rawData.Rows)
            {
                result.Add(DataRowToCustomer(dr));
            }
            return result;
        }

        public Customer GetCustomerByID(int CustomerID)
        {
            DataTable rawData = Custctx.GetCustomerByID(CustomerID);
            return DataRowToCustomer(rawData.Rows[0]);
        }

        public bool SaveNewCustomer(Customer Customer)
        {
            throw new NotImplementedException();
        }

        private Customer DataRowToCustomer(DataRow dr)
        {
            string housenradd;
            if (dr["Housenradd"] != DBNull.Value)
            {
                housenradd = dr.Field<string>("Housenradd");
            }
            else
            {
                housenradd = "";
            }
            return new Customer(
                Convert.ToInt16(dr.Field<decimal>("ID")),
                dr.Field<string>("Name"),
                dr.Field<string>("Email"),
                dr.Field<string>("Streetname"),
                Convert.ToInt16(dr.Field<int>("Housenr")),
                dr.Field<string>("City"),
                housenradd
                );
        }
    }
}