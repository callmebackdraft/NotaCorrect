using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaCorrect.Exceptions
{
    public class SqlQueryException : Exception
    {
        public SqlQueryException(string message)
            :base(message)
        {
        }
    }
}
