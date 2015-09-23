using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class TeamAddEventArgs : EventArgs
    {
        public TeamAddEvent Event { get; }

        public TeamAddEventArgs(TeamAddEvent e)
        {
            Event = e;
        }
    }
}
