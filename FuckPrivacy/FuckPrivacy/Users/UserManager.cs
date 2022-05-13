using System;
using System.IO;
using System.Net.NetworkInformation;

namespace FuckPrivacy.Users
{
    public static class UserManager
    {
        public static AUser Login(string email, string password) {
            // TODO
            if (email != "koznar.franta@gmail.com" || password != "Frantisek1235.") throw new ArgumentException();
            return new User(email, password);
        }

        public static AUser SignIn(string email, string password1, string password2) {
            if (UserExist(email)) throw new ArgumentException("User exist");
            if (password1 != password2) throw new ArgumentException("Passwords must be same");

            // TODO Save user to database
            return new User(email, password1);
        }

        public static bool UserExist(string email) {
            // TODO 
            //return Directory.Exists($@"C:\Users\Fanda\RiderProjects\FuckPrivacy\FuckPrivacy\FuckPrivacy\Users\Data\{email}");
            return email == "koznar.franta@gmail.com";
        }
    }
}