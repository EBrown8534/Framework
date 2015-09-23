using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class DeleteEventArgs : EventArgs
    {
        public DeleteEvent Event { get; }

        public DeleteEventArgs(DeleteEvent e)
        {
            Event = e;
        }
    }
}
