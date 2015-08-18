using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities.Logging
{
    public enum LoggingType : byte
    {
        Important = 0, // here for completeness, if the log is set to only include important messages then these are considered to be **extremely important** messages
        Error = 50, // anything from 0 to 50 is an error
        Warning = 100, // anything from 51 to 100 is a warning, this subset should include the error subset as well
        Information = 150, // anything from 101 to 150 is an informational message, this subset should include the warning subset and all encased subsets as well
        Verbose = 200, // anything from 151 to 200 is a verbose message, this subset should include the informational subset and all encased subsets as well
        All = 255, // include anything and everything.
    }
}
