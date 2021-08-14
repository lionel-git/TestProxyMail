using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace GenericProxy
{
    public class Proxy
    {
        public Proxy(int localPort, string remoteHost, int remotePort)
        {
            var server = new TcpListener(IPAddress.Any, localPort);
            server.Start();
            Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        var receiver = server.AcceptTcpClient();
                        var sender = new TcpClient(remoteHost, remotePort);
                        var t = Task.Run(() => RunTask(receiver, sender));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }

        private void RunTask(TcpClient receiver, TcpClient sender)
        {
            try
            {
                var senderStream = sender.GetStream();
                var receiverStream = receiver.GetStream();
                var task = Task.WhenAny(receiverStream.CopyToAsync(senderStream), senderStream.CopyToAsync(receiverStream));
                task.Wait();
                Console.WriteLine($"Done: {task.Status}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
