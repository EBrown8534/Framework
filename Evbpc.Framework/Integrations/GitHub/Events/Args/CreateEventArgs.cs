using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class CreateEventArgs : EventArgs
    {
        public CreateEvent Event { get; }

        public CreateEventArgs(CreateEvent e)
        {
            Event = e;
        }
    }
}
