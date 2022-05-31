using System;

namespace Client
{
    internal static class Program
    {
        public static void Main(string[] args) {
            for (var i = 0; i < 1000; i++) {
                var res = AsynchronousClient.StartClient(Console.ReadLine());
                Console.WriteLine(res);
            }
        }
    }
}