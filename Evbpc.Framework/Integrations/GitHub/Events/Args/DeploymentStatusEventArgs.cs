using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class DeploymentStatusEventArgs : EventArgs
    {
        public DeploymentStatusEvent Event { get; }

        public DeploymentStatusEventArgs(DeploymentStatusEvent e)
        {
            Event = e;
        }
    }
}
