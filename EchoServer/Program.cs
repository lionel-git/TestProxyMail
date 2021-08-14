using System;

namespace EchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var echoServer = new EchoServer(4555);
                Console.WriteLine("Press Key...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
