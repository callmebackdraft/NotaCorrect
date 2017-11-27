using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AE.Net.Mail;
using AE.Net.Mail.Imap;
using NotaCorrect.Exceptions;

namespace NotaCorrect.DataHandling
{
    public class ImapMailHandler
    {
        private string user;
        private string password;
        private ImapClient Imap;

        public ImapMailHandler(string userName, string Password)
        {
            user = userName;
            password = Password;
        }

        private void ConnectToServer()
        {
            try
            {
                Imap = new ImapClient("imap.gmail.com", "dennis.aspers@gmail.com", "tsrhcbrixvjnbgza", AuthMethods.Login, 993, true);
            }
            catch
            {
                throw new MailException("Unable to connect to server, possibly the usercredentials are incorrect");
            }
        }

        private void DisconnectFromServer()
        {
            try
            {
                Imap.Disconnect();
            }
            catch
            {
                throw new MailException("Unable to disconnect from server, are you actually connected ?");
            }
            
        }


        public IEnumerable<MailMessage> SearchEmail(string mailBox, string searchString)
        {
            ConnectToServer();
            List<MailMessage> result = new List<MailMessage>();
            try
            {
                Imap.SelectMailbox(mailBox);
            }
            catch
            {
                throw new MailException("Something went wrong while selecting the mailbox '" + mailBox + "' possibly it does not exist");
            }
            Lazy<MailMessage>[] LazyMailArray = Imap.SearchMessages(SearchCondition.Subject(searchString));
            foreach (Lazy<MailMessage> LM in LazyMailArray)
            {
                result.Add(LM.Value);
            }
            DisconnectFromServer();
            return result;
        }

        public IEnumerable<string> GetMailBoxNames()
        {
            ConnectToServer();
            List<string> result = new List<string>();

            try
            {
                Mailbox[] listMailboxes = Imap.ListMailboxes(string.Empty, "*");

                foreach (Mailbox listMailbox in listMailboxes)
                {
                    result.Add(listMailbox.Name);
                }

                return result;
            }
            catch
            {
                throw new MailException("Something went wrong while retreiving MailBox names, please check internet connectivity, username and password");
            }
            finally
            {
                DisconnectFromServer();
            }
        }

        public MailMessage GetMailByUid(int Uid)
        {
            try
            {
                return Imap.GetMessage(Uid);
            }
            catch
            {
                throw new MailException("Something went wrong with retreiving the Email, please check internet connectivity, username, password and/or the messageID");
            }
            finally
            {
                DisconnectFromServer();
            }
            
        }
    }
}