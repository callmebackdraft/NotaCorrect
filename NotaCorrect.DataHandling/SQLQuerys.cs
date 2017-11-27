using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using NotaCorrect.Interfaces;
using System.Data;


namespace NotaCorrect.DataHandling
{
    public class SQLQuerys
    {

        //internal static List<Invoice> GetAllInvoices()
        //{
        //    List<Invoice> result = new List<Invoice>();
        //    string query = "SELECT * FROM [Invoice]";
        //    SqlCommand cmd = new SqlCommand(query, EstablishConnection());
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        Invoice inv = new Invoice
        //        {
        //            ID = Convert.ToInt16(dr["ID"]),
        //            EmpID = Convert.ToInt16(dr["EmployeeID"]),
        //            Customer = GetCustomerByID(Convert.ToInt16(dr["CustomerID"])),
        //            CashPayment = Convert.ToDecimal(dr["CashPayment"]),
        //            MeetDate = Convert.ToDateTime(dr["MeetingDate"]),
        //            Status = dr["Status"].ToString(),
        //            LastChange = Convert.ToDateTime(dr["LastChangeDate"]),
        //            Type = dr["Type"].ToString(),
        //        };
        //        if (!DBNull.Value.Equals(dr["SentDate"]))
        //        {
        //            inv.SentDate = Convert.ToDateTime(dr["SentDate"]);
        //        }
        //        result.Add(inv);
        //    }
        //    return result;
        //}

        //internal static void ChangeInvoiceStatus(int invoiceID, string status)
        //{
        //    string query = "UPDATE Invoice SET Status = @Status , LastChangeDate = @DateTime   WHERE ID = @InvoiceID";
        //    SqlCommand cmd = new SqlCommand(query, EstablishConnection());
        //    cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
        //    cmd.Parameters.AddWithValue("@Status", status);
        //    cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
        //    cmd.ExecuteNonQuery();
        //}

        //internal static Invoice GetInvoiceByID(int id)
        //{
        //    List<Rentable> rentList = new List<Rentable>();
        //    string query = "SELECT Invoice_Rentable.InvoiceID, Invoice_Rentable.RentableID, Invoice.EmployeeID, Invoice.CustomerID, Invoice_Rentable.Amount, Invoice.CashPayment, Invoice.MeetingDate, Invoice.Status, Invoice.LastChangeDate, Invoice.Type, Invoice.SentDate, Rentable.Name as RentName, Rentable.Price, Customer.Name as CustName, Customer.Email, Rentable.Active as RentActive  FROM [Invoice_Rentable] JOIN Invoice ON Invoice_Rentable.InvoiceID = Invoice.ID JOIN Rentable ON Invoice_Rentable.RentableID = Rentable.ID JOIN Customer ON Invoice.CustomerID = Customer.ID WHERE InvoiceID = @InvID";
        //    SqlCommand cmd = new SqlCommand(query, EstablishConnection());
        //    cmd.Parameters.AddWithValue("@InvID", id);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    Invoice inv = new Invoice();
        //    while(dr.Read())
        //    {
        //        rentList.Add(new Rentable(Convert.ToInt16(dr["RentableID"]),dr["RentName"].ToString(),Convert.ToDecimal(dr["Price"]),(bool)dr["RentActive"],Convert.ToDecimal(dr["Amount"])));
        //        inv.ID = Convert.ToInt16(dr["InvoiceID"]);
        //        inv.EmpID = Convert.ToInt16(dr["EmployeeID"]);
        //        inv.Customer = GetCustomerByID(Convert.ToInt16(dr["CustomerID"]));
        //        inv.CashPayment = Convert.ToDecimal(dr["CashPayment"]);
        //        inv.MeetDate = Convert.ToDateTime(dr["MeetingDate"]);
        //        inv.Status = dr["Status"].ToString();
        //        inv.LastChange = Convert.ToDateTime(dr["LastChangeDate"]);
        //        inv.Type = dr["Type"].ToString();
        //        if (!DBNull.Value.Equals(dr["SentDate"]))
        //        {
        //            inv.SentDate = Convert.ToDateTime(dr["SentDate"]);
        //        }
        //    }
        //    dr.Close();
        //    inv.RentedList = rentList;
        //    return inv;
        //}

        //private static Customer GetCustomerByID(int id)
        //{

        //    string query = "SELECT * FROM [Customer] WHERE ID = @CustID";
        //    SqlCommand cmd = new SqlCommand(query, EstablishConnection());
        //    cmd.Parameters.AddWithValue("@CustID", id);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        return new Customer(Convert.ToInt16(dr["ID"]), dr["Name"].ToString(), dr["Email"].ToString(),dr["Streetname"].ToString(), Convert.ToInt16(dr["Housenr"]), dr["City"].ToString(), dr["Housenradd"].ToString());
        //    }
        //    dr.Close();
        //    throw new Exception("Woops Something broke");
        //}

        //public static int SaveJustification(Justification just)
        //{
        //    string query = "INSERT INTO [Invoice](EmployeeID, CustomerID, Cashpayment, MeetingDate, Status, LastChangeDate, Type) VALUES (@EmpID,@CustID,@Cash,@MeetDate,@Status,@LastChange,@Type); SELECT SCOPE_IDENTITY();";
        //    SqlCommand cmd = new SqlCommand(query, EstablishConnection());
        //    cmd.Parameters.AddWithValue("@EmpID", just.EmpID);
        //    cmd.Parameters.AddWithValue("@CustID", just.SelectedCustID);
        //    cmd.Parameters.AddWithValue("@Cash", just.CashPayment);
        //    cmd.Parameters.AddWithValue("@MeetDate", just.MeetDate);
        //    cmd.Parameters.AddWithValue("@Status", "Justified");
        //    cmd.Parameters.AddWithValue("@LastChange", DateTime.Now);
        //    cmd.Parameters.AddWithValue("@Type", "Regular");
        //    //cmd.Parameters.AddWithValue("@SentDate", null);
        //    int InvoiceID = Convert.ToInt16(cmd.ExecuteScalar());
        //    cmd.Parameters.Clear();
        //    List<KeyValuePair<string, int>> rentables = GetAllRentables();
        //    cmd.CommandText = "INSERT INTO [Invoice_Rentable](InvoiceID,RentableID,Amount) VALUES (@InvID,@RentID,@Amount)";
        //    foreach (KeyValuePair<string, int> kvp in rentables)
        //    {
        //        cmd.Parameters.AddWithValue("@InvID", InvoiceID);
        //        cmd.Parameters.AddWithValue("@RentID", kvp.Value);
        //        decimal billableAmount = 0;
        //        switch (kvp.Key)
        //        {
        //            case "Huur Kleine Zaal":
        //                billableAmount = just.RentLittleRoom;
        //                break;
        //            case "Huur Grote Zaal":
        //                billableAmount = just.RentLargeRoom;
        //                break;
        //            case "Gebruik Keuken tot 24 personen":
        //                if (just.KitchenUsedFor == 1)
        //                {
        //                    billableAmount = 1;
        //                }
        //                else
        //                {
        //                    billableAmount = 0;
        //                }
        //                break;
        //            case "Gebruik Keuken vanaf 25 personen":
        //                if (just.KitchenUsedFor == 2)
        //                {
        //                    billableAmount = 1;
        //                }
        //                else
        //                {
        //                    billableAmount = 0;
        //                }
        //                break;
        //            case "Gebruik Beamer":
        //                if (just.BeamerRented)
        //                {
        //                    billableAmount = 1;
        //                }
        //                else
        //                {
        //                    billableAmount = 0;
        //                }
        //                break;
        //            case "Gebruik Microfoon":
        //                if (just.MicRented)
        //                {
        //                    billableAmount = 1;
        //                }
        //                else
        //                {
        //                    billableAmount = 0;
        //                }
        //                break;
        //            case "Koffie/Thee/Fris":
        //                billableAmount = just.CoffeeAmount;
        //                break;
        //            case "Bier":
        //                billableAmount = just.BeerAmount;
        //                break;
        //            case "Wijn/Belegd Broodje":
        //                billableAmount = just.WineAmount;
        //                break;
        //            case "Koffie/Thee Kan":
        //                billableAmount = just.JugAmount;
        //                break;
        //            case "Diverse/Overige Kosten":
        //                billableAmount = just.OtherAmount;
        //                break;
        //        }

        //        if (billableAmount != 0)
        //        {
        //            cmd.Parameters.AddWithValue("Amount", billableAmount);
        //            cmd.ExecuteNonQuery();
        //        }
        //        cmd.Parameters.Clear();
        //    }
        //    return InvoiceID;
        //}

        //private static List<KeyValuePair<string, int>> GetAllRentables()
        //{
        //    List<KeyValuePair<string, int>> result = new List<KeyValuePair<string, int>>();
        //    string query = "SELECT * FROM [Rentable]";
        //    SqlCommand cmd = new SqlCommand(query, EstablishConnection());
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        KeyValuePair<string, int> kvp = new KeyValuePair<string, int>(dr["Name"].ToString(), Convert.ToInt16(dr["ID"]));
        //        result.Add(kvp);
        //    }
        //    return result;
        //}

        //private static Rentable GetRentableByID(int id)
        //{
        //    Rentable result = null;
        //    string query = "SELECT * FROM [Rentable] WHERE ID = @ID";
        //    SqlCommand cmd = new SqlCommand(query, EstablishConnection());
        //    cmd.Parameters.AddWithValue("@ID", id);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        result = new Rentable(Convert.ToInt16(dr["ID"]), dr["Name"].ToString(), Convert.ToDecimal(dr["Price"]), Convert.ToBoolean(dr["Active"]));
        //    }
        //    return result;
        //}

        //public static List<SelectListItem> GetAllCustomers()
        //{
        //    List<SelectListItem> result = new List<SelectListItem>();
        //    string query = "Select * FROM [Customer]";
        //    SqlCommand cmd = new SqlCommand(query, EstablishConnection());
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        result.Add(new SelectListItem { Value = dr["ID"].ToString(), Text = dr["Name"].ToString()});
        //    }
        //    result.Add(new SelectListItem { Value = null, Text = "", Selected = true });
        //    return result;
        //}
    }
}