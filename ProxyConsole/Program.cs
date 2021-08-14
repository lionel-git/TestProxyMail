using System;
using ConfigHandler;
using GenericProxy;

namespace ProxyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var config = BaseConfig.LoadAll<ProxyConfig>("proxyConfig.json", args);
                if (config.Help)
                    return;
                Console.WriteLine($"Config:\n{config.ToStringFlat()}");
                var proxy = new Proxy(7777, "localhost", 4555);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
