using System;
using Server.Servers;

namespace Server
{
    internal static class Program
    {
        /**/
        [Obsolete("Obsolete")]
        public static void Main(string[] args) {
            Servers.Server.Run();
        }
        /**/
    }
}