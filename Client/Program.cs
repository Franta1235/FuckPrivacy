using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        // ReSharper disable once InconsistentNaming
        private const int PORT_NO = 8001;

        // ReSharper disable once InconsistentNaming
        private const string SERVER_IP = "109.80.246.1";

        public static void Main(string[] args) {
            while (true) {
                var textToSend = Console.ReadLine();

                //---create a TCPClient object at the IP and port no.---
                var client = new TcpClient(SERVER_IP, PORT_NO);
                var nwStream = client.GetStream();
                var bytesToSend = Encoding.ASCII.GetBytes(textToSend ?? string.Empty);

                //---send the text---
                Console.WriteLine("Sending : " + textToSend);
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                //---read back the text---
                var bytesToRead = new byte[client.ReceiveBufferSize];
                var bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}