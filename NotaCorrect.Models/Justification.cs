using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NotaCorrect.Models
{
    public class Justification
    {
        public int EmpID { get;  set; }
        [Required(ErrorMessage = "Je dient een Datum te selecteren")]
        [DateTimeRange(ErrorMessage = "Je dient een correcte Datum te selecteren")]
        public DateTime MeetDate { get;  set; }
        [Required(ErrorMessage = "Je dient een klant te selecteren")]
        public int SelectedCustID { get;  set; }
        public IEnumerable<Customer> AllCustomers { get; set; }
        public int RentLittleRoom { get;  set; }
        public int RentLargeRoom { get;  set; }
        public int KitchenUsedFor { get;  set; }
        public int CoffeeAmount { get;  set; }
        public int BeerAmount { get; set; }
        public int WineAmount { get; set; }
        public int JugAmount { get; set; }
        public decimal OtherAmount { get; set; }
        public bool BeamerRented { get;  set; }
        public bool MicRented { get;  set; }
        public decimal CashPayment { get;  set; }

        public Justification()
        {
           // AllCustomers = SQLConnect.GetAllCustomers();
        }

        public int Save()
        {
            // return SQLConnect.SaveJustification(this);
            throw new NotImplementedException();
        }
        
    }
}