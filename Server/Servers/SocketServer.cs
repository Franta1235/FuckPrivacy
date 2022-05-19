using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server.Servers
{
    public class SocketServer
    {
        // ReSharper disable once InconsistentNaming
        private const int PORT_NO = 5000;

        // ReSharper disable once InconsistentNaming
        private const string SERVER_IP = "127.0.0.1";

        public SocketServer() {
            //---listen at the specified IP and port no.---
            var localAdd = IPAddress.Parse(SERVER_IP);
            var listener = new TcpListener(localAdd, PORT_NO);
            Console.WriteLine("Socket server started.");
            listener.Start();

            while (true) {
                //---incoming client connected---
                var client = listener.AcceptTcpClient();

                //---get the incoming data through a network stream---
                var nwStream = client.GetStream();
                var buffer = new byte[client.ReceiveBufferSize];

                //---read incoming stream---
                var bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                //---convert the data received into a string---
                var dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received : " + dataReceived);

                //---write back the text to the client---
                Console.WriteLine("Sending back : " + dataReceived);
                nwStream.Write(buffer, 0, bytesRead);
                client.Close();
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}