using System;
using FuckPrivacy.Client.Helper;

namespace FuckPrivacy.Client
{
    public static partial class AsynchronousClient
    {
        public static bool UserExist(string username) {
            var result = AsynchronousClient.StartClient($"{ServerMethods.UserExist}{MethodSplitter}{username}");
            return result == true.ToString();
        }
    }
}