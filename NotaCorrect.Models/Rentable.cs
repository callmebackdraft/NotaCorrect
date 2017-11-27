using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotaCorrect.Models
{
    public class Rentable
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
        public decimal Amount { get; private set; }

        public Rentable()
        {

        }

        public Rentable(int id, string name, decimal price, bool active)
        {
            ID = id;
            Name = name;
            Price = price;
            Active = active;
        }

        public Rentable(int id, string name, decimal price, bool active, decimal amount)
        {
            ID = id;
            Name = name;
            Price = price;
            Active = active;
            Amount = amount;
        }

        public void AddAmount(decimal amount)
        {
            Amount = amount;
        }
    }
}