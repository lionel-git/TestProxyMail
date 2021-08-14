using System;
using System.Net.Sockets;
using System.Text;

namespace ClientTester
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using var client = new TcpClient();
                client.Connect("localhost", 4555);
                var msg = "Hello world";
                for (int i = 0; i < 10; i++)
                {
                    client.GetStream().Write(Encoding.ASCII.GetBytes(msg));
                    var buffer = new byte[1024 * 1024];
                    int length = client.GetStream().Read(buffer, 0, buffer.Length);
                    Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, length));
                    Console.WriteLine("====");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }
    }
}
