﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EchoServer
{
    public class EchoServer
    {
        public EchoServer(int port)
        {
            var server = new TcpListener(IPAddress.Any, port);
            server.Start();
            Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        var receiver = server.AcceptTcpClient();                        
                        var t = Task.Run(() => RunTask(receiver));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });

        }

        private void RunTask(TcpClient receiver)
        {
            try
            {
                var remoteEndPoint = receiver.Client.RemoteEndPoint.ToString();
                Console.WriteLine($"Connection opened: {remoteEndPoint}");
                var receiverStream = receiver.GetStream();
                var buffer = new byte[1024*1024];
                int length;
                do
                {
                    length = receiverStream.Read(buffer, 0, buffer.Length);
                    receiverStream.Write(buffer, 0, length);
                    Console.WriteLine($"Exchanged length = {length}");
                }
                while (length > 0);
                Console.WriteLine($"Connection closed {remoteEndPoint}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}