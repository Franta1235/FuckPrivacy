using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using FuckPrivacy.Server;

namespace Server.Servers
{
    public class SocketServer
    {
        // ReSharper disable once InconsistentNaming
        private const int PORT_NO = 5000;

        // ReSharper disable once InconsistentNaming
        private const string SERVER_IP = "127.0.0.1";

        private readonly Server _server;

        public SocketServer(Server server) {
            _server = server;
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
                var dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead).Split(';');
                Console.WriteLine($"{dataReceived[0]}: {dataReceived[1]}");

                switch ((ServerMethods) Enum.Parse(typeof(ServerMethods), dataReceived[0], true)) {
                    case ServerMethods.UserExist:
                        var bytesToSend = UserExist(dataReceived[1]);
                        nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                client.Close();
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private byte[] UserExist(string data) {
            var bytesToSend = Encoding.ASCII.GetBytes(_server.UserExist(data).ToString());
            return bytesToSend;
        }
    }
}