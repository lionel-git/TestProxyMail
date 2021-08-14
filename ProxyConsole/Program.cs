using System;
using GenericProxy;

namespace ProxyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
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
