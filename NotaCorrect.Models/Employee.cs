using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotaCorrect.Models
{
    public class Employee
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public Employee(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}