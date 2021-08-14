using ConfigHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyConsole
{
    public class ProxyConfig : BaseConfig
    {
        [Option("Port to listen to")]
        public int LocalPort { get; set; }

        public ProxyConfig()
        {

        }

    }
}
