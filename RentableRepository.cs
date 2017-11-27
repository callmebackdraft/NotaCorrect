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
    public class RentableRepository : IRentableRepository
    {
        IRentableContext Rentctx;

        public RentableRepository()
        {
            Rentctx = new SQLConnect();
        }

        public List<Rentable> GetAllRentables()
        {
            List<Rentable> result = new List<Rentable>();
            DataTable rawData = Rentctx.GetAllRentables();
            foreach(DataRow dr in rawData.Rows)
            {
                result.Add(DataRowToRentable(dr));
            }
            return result;
        }

        public Rentable GetRentableByID(int RentableID)
        {
            DataTable rawData = Rentctx.GetRentableByID(RentableID);
            return DataRowToRentable(rawData.Rows[0]);
        }

        public List<Rentable> GetRentablesForInvoice(int InvoiceID)
        {
            List<Rentable> result = new List<Rentable>();
            DataTable rawData = Rentctx.GetRentablesForInvoice(InvoiceID);
            foreach (DataRow dr in rawData.Rows)
            {
                Rentable subresult = GetRentableByID(Convert.ToInt16(dr.Field<decimal>("RentableID")));
                subresult.AddAmount(dr.Field<decimal>("Amount"));
                result.Add(subresult);
            }
            return result;
        }

        private Rentable DataRowToRentable(DataRow dr)
        {
            return new Rentable(
                Convert.ToInt16(dr.Field<decimal>("ID")),
                dr.Field<string>("Name"),
                dr.Field<decimal>("Price"),
                dr.Field<Boolean>("Active")
                );
        }
    }
}