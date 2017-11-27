using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotaCorrect.Models;
using Rotativa;
using Rotativa.MVC;
using System.Net.Mail;
using System.Net;
using System.IO;
using AE.Net.Mail;
using NotaCorrect.Interfaces;
using NotaCorrect.Repository;
using NotaCorrect.DataHandling;

namespace NotaCorrect.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult Justification()
        {
            ViewBag.Title = "Afdrachtformulier";
            if (TempData["ProcessResult"] != null)
            {
                ViewBag.ProcessMessage = TempData["ProcessResult"];
            }
            Justification justification = new Justification();
            justification.EmpID = 10000;
            return View(justification);
        }

        public ActionResult Invoicing()
        {
            ViewBag.Title = "Verwerk Nota's";
            IInvoiceRepository InvRepo = new InvoiceRepository();
            
            List<Invoice> invList = InvRepo.GetAllInvoices();
            return View(invList);
        }

        public ActionResult ShowInvoice(int InvoiceID)
        {
            ViewBag.Title = "Nota: " + InvoiceID;
            return View(new InvoiceRepository().GetInvoiceByID(InvoiceID));
        }

        [HttpPost]
        public ActionResult ProcessJustification(Justification just)
        {
            TempData["ProcessResult"] = "Afdrachtformulier Succesvol verwerk, Notanummer: " + just.Save();
            
            return RedirectToAction("Justification");
        }

        public ActionResult GetPDFInvoice(int InvoiceID)
        {
            try
            {
                var report = new ViewAsPdf("PartialInvoice", new InvoiceRepository().GetInvoiceByID(InvoiceID))
                {
                    FileName = "Nota:" + InvoiceID.ToString(),
                };
                return report;
            }
            catch (Exception e)
            {
                throw new Exception("An Error Occured while creating PDF please try again: " + e.Message);
            }   
        }

        public async System.Threading.Tasks.Task<ActionResult> SendInvoiceByMailAsync(int InvoiceID)
        {

            Invoice inv = new InvoiceRepository().GetInvoiceByID(InvoiceID);
            var body = System.IO.File.ReadAllText(Server.MapPath(@"~\Content\EmailTemplate.cshtml"));
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            try
            {
                msg.From = new MailAddress("dennis.aspers@gmail.com");
                msg.To.Add(new MailAddress(inv.Customer.Email));
                msg.Subject = "Nota: " + inv.ID + " voor de bijeenkomst op: " + inv.MeetDate.ToString("dd/MM/yyyy");
                msg.Body = string.Format(body, inv.Customer.Name, inv.MeetDate.ToString("dd/MM/yyyy"), inv.ID);
                msg.IsBodyHtml = true;
                MemoryStream strm = new MemoryStream(((ViewAsPdf)GetPDFInvoice(inv.ID)).BuildPdf(ControllerContext));
                System.Net.Mail.Attachment pdfatt = new System.Net.Mail.Attachment(strm, InvoiceID + ".pdf", "application/pdf");
                msg.Attachments.Add(pdfatt);
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("dennis.aspers@gmail.com", "tsrhcbrixvjnbgza");
                smtpClient.EnableSsl = true;
                await smtpClient.SendMailAsync(msg);
                IInvoiceRepository InvRepo = new InvoiceRepository();
                InvRepo.ChangeInvoiceStatus(InvoiceID, "Sent");
            }
            catch (Exception e)
            {
                throw e;
            }

            return RedirectToAction("Invoicing");
        }

        public ActionResult MailConversation(int InvoiceID)
        {
            List<AE.Net.Mail.MailMessage> maillist = new ImapMailHandler("", "").SearchEmail("INBOX", InvoiceID.ToString()).ToList();
            maillist.AddRange(new ImapMailHandler("", "").SearchEmail("[Gmail]/Sent Mail", InvoiceID.ToString()).ToList());
            List<AE.Net.Mail.MailMessage> sortedMails = maillist.OrderBy(o => o.Date).ToList();
            return View(sortedMails);
        }
        
        [HttpGet]
        public ActionResult Mailview(string MessageID, bool Received)
        {
            ImapClient imc = new ImapClient("imap.gmail.com", "dennis.aspers@gmail.com", "tsrhcbrixvjnbgza", AuthMethods.Login, 993, true);
            if (Received)
            {
                imc.SelectMailbox("INBOX");
            }
            else
            {
                imc.SelectMailbox("[Gmail]/Sent Mail");
            }

            return View(imc.GetMessage(MessageID));
        }

        [HttpPost]
        public string InvoicePayment(int InvoiceID)
        {
            return "Nog niet geimplementeerd";
        }

        public ActionResult TestView()
        {

            return View();
        }
    }
}