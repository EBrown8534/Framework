using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class DeploymentEventArgs : EventArgs
    {
        public DeploymentEvent Event { get; }

        public DeploymentEventArgs(DeploymentEvent e)
        {
            Event = e;
        }
    }
}
