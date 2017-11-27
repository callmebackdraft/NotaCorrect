using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotaCorrect;
using NotaCorrect.Repository;
using NotaCorrect.Models;
using NotaCorrect.DataHandling;

namespace NotaCorrectTests
{
    [TestClass]
    public class InvoicingTests
    {
        [TestMethod]
        public void InvoicingTests1()
        {
            InvoiceRepository invRepo = new InvoiceRepository();
            Invoice inv = invRepo.GetInvoiceByID(10015);
            Assert.AreEqual(10000, inv.Customer.ID);
        }
    }
}
