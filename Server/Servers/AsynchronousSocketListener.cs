using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FuckPrivacy.Client;
using FuckPrivacy.Client.Helper;
using Google.Protobuf.WellKnownTypes;
using Enum = System.Enum;

namespace Server.Servers
{
    public static class AsynchronousSocketListener
    {
        // Thread signal.
        private static readonly ManualResetEvent AllDone = new ManualResetEvent(false);

        [Obsolete("Obsolete")]
        public static void StartListening() {
            // Establish the local endpoint for the socket. The DNS name of the computer.
            var ipHostInfo = Dns.Resolve(Dns.GetHostName());
            var ipAddress = ipHostInfo.AddressList[0];
            var localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.
            var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.
            try {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true) {
                    // Set the event to non-signaled state.
                    AllDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);

                    // Wait until a connection is made before continuing.
                    AllDone.WaitOne();
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadKey();
        }

        private static void AcceptCallback(IAsyncResult ar) {
            // Signal the main thread to continue.
            AllDone.Set();

            // Get the socket that handles the client request.
            var listener = (Socket) ar.AsyncState;
            var handler = listener.EndAccept(ar);

            // Create the state object.
            var state = new StateObject {
                WorkSocket = handler
            };
            handler.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }

        private static void ReadCallback(IAsyncResult ar) {
            // Retrieve the state object and the handler socket from the asynchronous state object.
            var state = (StateObject) ar.AsyncState;
            var handler = state.WorkSocket;

            // Read data from the client socket. 
            var bytesRead = handler.EndReceive(ar);

            if (bytesRead <= 0) return;
            // There  might be more data, so store the data received so far.
            state.Sb.Append(Encoding.ASCII.GetString(state.Buffer, 0, bytesRead));

            // Check for end-of-file tag. If it is not there, read more data.
            var content = state.Sb.ToString();
            if (content.IndexOf(AsynchronousClient.EndOfFile, StringComparison.Ordinal) > -1) {
                // All the data has been read from the client. Display it on the console.
                Console.WriteLine($"Read {content.Length} bytes from socket.");
                content = content.Substring(0, content.Length - AsynchronousClient.EndOfFile.Length);
                var tokens = content.Split(new[] {AsynchronousClient.MethodSplitter}, StringSplitOptions.None);

                var method = tokens[0];
                var input = tokens[1];
                var result = string.Empty;


                switch ((ServerMethods) Enum.Parse(typeof(ServerMethods), method, true)) {
                    case ServerMethods.UserExist:
                        result = MySqlServer.UserExist(input).ToString();
                        break;
                    default:
                        break;
                }

                // Echo the data back to the client.
                Send(handler, $"{result}{AsynchronousClient.EndOfFile}");
            }
            else {
                // Not all data received. Get more.
                handler.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
            }
        }

        private static void Send(Socket handler, string data) {
            // Convert the string data to byte data using ASCII encoding.
            var byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar) {
            try {
                // Retrieve the socket from the state object.
                var handler = (Socket) ar.AsyncState;

                // Complete sending the data to the remote device.
                var bytesSent = handler.EndSend(ar);
                Console.WriteLine($"Sent {bytesSent} bytes to client.");

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}