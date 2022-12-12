using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data
{
    public class PersoonException : Exception
    {
        public PersoonException(String message)
            : base(message)
        {}
    }
}
