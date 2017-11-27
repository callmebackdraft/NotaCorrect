using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotaCorrect.Exceptions
{
    public class MailException : Exception
    {
        public MailException(string message)
            :base(message)
        {
        }

    }
}