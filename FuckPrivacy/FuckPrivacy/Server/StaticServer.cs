using System;
using System.Net.Sockets;
using System.Text;

namespace FuckPrivacy.Server
{
    public static class StaticServer
    {
        public static bool UserExist(string username) {
            // ReSharper disable once InconsistentNaming
            const int PORT_NO = 5000;

            // ReSharper disable once InconsistentNaming
            const string SERVER_IP = "127.0.0.1";

            //---create a TCPClient object at the IP and port no.---
            var client = new TcpClient(SERVER_IP, PORT_NO);
            var nwStream = client.GetStream();
            var bytesToSend = Encoding.ASCII.GetBytes($"{ServerMethods.UserExist};{username}");
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            //---read back the text---
            var bytesToRead = new byte[client.ReceiveBufferSize];
            var bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            var result = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);

            return result == "True";
        }
    }
}