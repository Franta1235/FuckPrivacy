using System;
using FuckPrivacy.Users;

namespace Server.Servers
{
    public static class Server
    {
        [Obsolete("Obsolete")]
        public static void Run() {
            MySqlServer.Run();
            AsynchronousSocketListener.StartListening();
        }
    }
}