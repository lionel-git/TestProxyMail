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
                        var t1 = Task.Run(() => RunTask(" => ", receiver, sender));
                        var t2 = Task.Run(() => RunTask(" <= ", sender, receiver));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }

        private void RunTask(string name, TcpClient receiver, TcpClient sender)
        {
            Console.WriteLine($"Link established {receiver.Client.RemoteEndPoint} => {sender.Client.RemoteEndPoint}");
            Console.WriteLine($"Local: {receiver.Client.LocalEndPoint} | {sender.Client.LocalEndPoint}");
            try
            {
                var senderStream = sender.GetStream();
                var receiverStream = receiver.GetStream();
                var buffer = new byte[1024 * 1024];
                int length;
                do
                {
                    length = receiverStream.Read(buffer, 0, buffer.Length);
                    senderStream.Write(buffer, 0, length);
                    Console.WriteLine($"{name} : length = {length}");
                }
                while (length > 0);
                Console.WriteLine($"{name}: Done");
                receiver.Dispose();
                sender.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{name}: {ex}");
            }
        }
    }
}
