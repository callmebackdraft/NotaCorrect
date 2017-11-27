using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotaCorrect.Models
{
    public class Invoice
    {
        public int ID { get; private set; }
        public Employee Employee { get; private set; }
        public Customer Customer { get; private set; }
        public decimal CashPayment { get; private set; }
        public DateTime MeetDate { get; private set; }
        public string Status { get; private set; }
        public DateTime LastChange { get; private set; }
        public List<Rentable> RentedList { get; private set; }
        public string Type { get; private set; }
        public DateTime SentDate { get; private set; }

        public Invoice(int id, Employee emp, Customer cust, decimal cashpayment, DateTime meetdate, string status, DateTime lastchange, List<Rentable> rentlist, string type)
        {
            ID = id;
            Employee = emp;
            Customer = cust;
            CashPayment = cashpayment;
            MeetDate = meetdate;
            Status = status;
            LastChange = lastchange;
            RentedList = rentlist;
            Type = type;
        }

        public void AddSentDate(DateTime sentdate)
        {
            SentDate = sentdate;
        }

        public override string ToString()
        {
            string result = ID + " " + Customer.Name + " " + MeetDate.ToString("dd/MM/yyyy"); 

            return result;
        }
    }
}