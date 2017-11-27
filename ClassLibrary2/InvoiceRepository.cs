using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotaCorrect.Interfaces;
using NotaCorrect.Models;
using NotaCorrect.DataHandling;
using System.Data;

namespace NotaCorrect.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {

        IInvoiceContext Invctx;

        public InvoiceRepository()
        {
            Invctx = new InvoiceSQLQuery();
        }

        public void ChangeInvoiceStatus(int invoiceID, string status)
        {
            Invctx.ChangeInvoiceStatus(invoiceID, status);
        }

        public List<Invoice> GetAllInvoices()
        {
            List<Invoice> result = new List<Invoice>();
            DataTable rawData = Invctx.GetAllInvoices();
            foreach (DataRow dr in rawData.Rows)
            {
                result.Add(DataRowToInvoice(dr));
            }
            return result;
        }

        public Invoice GetInvoiceByID(int invoiceID)
        {
            DataTable rawData = Invctx.GetInvoiceByID(invoiceID);
            return DataRowToInvoice(rawData.Rows[0]);
        }

        private Invoice DataRowToInvoice(DataRow dr)
        {
            Invoice result = new Invoice(
                Convert.ToInt16(dr.Field<decimal>("ID")),
                new EmployeeRepository().GetEmployeeByID(Convert.ToInt16(dr.Field<decimal>("EmployeeID"))),
                new CustomerRepository().GetCustomerByID(Convert.ToInt16(dr.Field<decimal>("CustomerID"))),
                dr.Field<decimal>("CashPayment"),
                dr.Field<DateTime>("MeetingDate"),
                dr.Field<string>("Status"),
                dr.Field<DateTime>("LastChangeDate"),
                new RentableRepository().GetRentablesForInvoice(Convert.ToInt16(dr.Field<decimal>("ID"))),
                dr.Field<string>("Type")
                );
            if(dr["SentDate"] != DBNull.Value)
            {
                result.AddSentDate(dr.Field<DateTime>("SentDate"));
            }
            return result;
        }

    }
}