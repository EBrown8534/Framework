using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class PageBuildEventArgs : EventArgs
    {
        public PageBuildEvent Event { get; }

        public PageBuildEventArgs(PageBuildEvent e)
        {
            Event = e;
        }
    }
}
