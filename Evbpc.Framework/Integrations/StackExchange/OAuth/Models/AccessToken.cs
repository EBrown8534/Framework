using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.OAuth.Models
{
    public class AccessToken : IBaseModel
    {
        public string Token { get; private set; }
        public long Expires { get; private set; }

        public void Deserialize(string response)
        {
            var items = response.Split('&');
            Token = items[0].Split('=')[1];
            Expires = Convert.ToInt32(items[1].Split('=')[1]);
        }
    }
}
