using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamGenocide.Exceptions
{
    public class InvalidAnnouncementException : Exception
    {
        public InvalidAnnouncementException(string msg) : base(msg)
        {
        }
    }
}
