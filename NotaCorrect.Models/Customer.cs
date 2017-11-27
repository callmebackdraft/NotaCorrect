namespace NotaCorrect.Models
{
    public class Customer
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Streetname { get; private set; }
        public int Housenr { get; private set; }
        public string City { get; private set; }
        public string Housenradd { get; private set; }

        public Customer(int id, string name, string email, string streetname, int housenr, string city, string housenradd)
        {
            ID = id;
            Name = name;
            Email = email;
            Streetname = streetname;
            Housenr = housenr;
            City = city;
            Housenradd = housenradd;
        }
    }
}