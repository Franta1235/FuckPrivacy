using System;
using System.IO;
using System.Net.NetworkInformation;

namespace FuckPrivacy.Users
{
    public static class UserManager
    {
        public static AUser Login(string username, string password) {
            throw new NotImplementedException();
        }

        public static AUser SignIn(string username, string password1, string password2) {
            throw new NotImplementedException();
        }

        public static bool UserExist(string email) {
            // TODO 
            //return Directory.Exists($@"C:\Users\Fanda\RiderProjects\FuckPrivacy\FuckPrivacy\FuckPrivacy\Users\Data\{email}");
            return email == "koznar.franta@gmail.com";
        }
    }
}