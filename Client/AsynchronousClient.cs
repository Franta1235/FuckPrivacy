using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    public static partial class AsynchronousClient
    {
        // The port number for the remote device.  
        private const int Port = 11000;

        // ManualResetEvent instances signal completion.  
        private static readonly ManualResetEvent ConnectDone = new ManualResetEvent(false);
        private static readonly ManualResetEvent SendDone = new ManualResetEvent(false);
        private static readonly ManualResetEvent ReceiveDone = new ManualResetEvent(false);

        // The response from the remote device.  
        private static string _response = string.Empty;

        public static string StartClient(string data) {
            Reset();

            // Connect to a remote device.  
            try {
                // Establish the remote endpoint for the socket.
                var ipAddress = IPAddress.Parse("192.168.42.10");
                var remoteEp = new IPEndPoint(ipAddress, Port);

                // Create a TCP/IP socket.  
                var client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.  
                client.BeginConnect(remoteEp, new AsyncCallback(ConnectCallback), client);
                ConnectDone.WaitOne();

                // Send data to the remote device.  
                Send(client, $"{data}{AsynchronousSocketListener.EndOfFile}");
                SendDone.WaitOne();

                // Receive the response from the remote device.  
                Receive(client);
                ReceiveDone.WaitOne();

                // Write the response to the console.  
                //Console.WriteLine($"Response received : {_response}");

                // Release the socket.  
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }

            return _response.Substring(0, _response.Length - AsynchronousSocketListener.EndOfFile.Length);
        }

        private static void ConnectCallback(IAsyncResult ar) {
            try {
                // Retrieve the socket from the state object.  
                var client = (Socket) ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                Console.WriteLine($"Socket connected to {client.RemoteEndPoint}");

                // Signal that the connection has been made.  
                ConnectDone.Set();
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Receive(Socket client) {
            try {
                // Create the state object.  
                var state = new StateObject {
                    WorkSocket = client
                };

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar) {
            try {
                // Retrieve the state object and the client socket from the asynchronous state object.  
                var state = (StateObject) ar.AsyncState;
                var client = state.WorkSocket;

                // Read data from the remote device.  
                var bytesRead = client.EndReceive(ar);

                if (bytesRead > 0) {
                    // There might be more data, so store the data received so far.  
                    state.Sb.Append(Encoding.ASCII.GetString(state.Buffer, 0, bytesRead));

                    // Get the rest of the data.  
                    client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                }
                else {
                    // All the data has arrived; put it in response. 
                    if (state.Sb.Length > 1) {
                        _response = state.Sb.ToString();
                    }

                    // Signal that all bytes have been received.  
                    ReceiveDone.Set();
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket client, string data) {
            // Convert the string data to byte data using ASCII encoding.  
            var byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, data.Length, 0, new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar) {
            try {
                // Retrieve the socket from the state object.  
                var client = (Socket) ar.AsyncState;

                // Complete sending the data to the remote device.  
                var bytesSent = client.EndSend(ar);
                Console.WriteLine($"Sent {bytesSent} bytes to server.");

                // Signal that all bytes have been sent.  
                SendDone.Set();
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Reset() {
            ConnectDone.Reset();
            SendDone.Reset();
            ReceiveDone.Reset();
        }

        public static byte[] StringToBytes(string s) {
            return Encoding.ASCII.GetBytes(s);
        }

        public static string BytesToString(byte[] bytes) {
            return Encoding.ASCII.GetString(bytes);
        }
        
    }
}