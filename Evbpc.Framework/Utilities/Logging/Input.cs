using Evbpc.Framework.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities.Logging
{
    public class Input
    {
        public DateTime DateTime { get; set; }
        public Severity Severity { get; set; }
        public string Message { get; set; }
        public string DateTimeFormat { get; set; }
    }
}
