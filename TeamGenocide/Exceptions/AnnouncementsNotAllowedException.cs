using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamGenocide.Exceptions
{
    public class AnnouncementsNotAllowedException : Exception
    {
        public AnnouncementsNotAllowedException(string msg) : base(msg)
        {
        }
    }
}
